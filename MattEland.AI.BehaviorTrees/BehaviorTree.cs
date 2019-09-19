using System;
using System.Collections.Generic;
using System.Linq;

namespace MattEland.AI.BehaviorTrees
{
    public class BehaviorTree<T>
    {
        public IBehaviorNode<T> Child { get; set; }

        public BehaviorResult<T> Evaluate(T context)
        {
            return Child?.Evaluate(context);
        }
    }

    public interface IBehaviorNode<T>
    {
         BehaviorResult<T> Evaluate(T context);
    }

    public class BehaviorSequence<T> : IBehaviorNode<T>
    {
        public BehaviorSequence(IEnumerable<IBehaviorNode<T>> children)
        {
            Children = children != null 
                ? children.ToList() 
                : throw new ArgumentException("You must provide a non-empty collection to a sequence", nameof(children));
        }

        public IEnumerable<IBehaviorNode<T>> Children { get; }
        public BehaviorResult<T> Evaluate(T context)
        {
            foreach (var child in Children)
            {
                var childResult = child.Evaluate(context);
                if (childResult.SelectedNode != null)
                {
                    return childResult;
                }
            }

            var result = new BehaviorResult<T>();
            return result;
        }
    }

    public class BehaviorResult<T>
    {
        public IBehaviorNode<T> SelectedNode { get; set; }
        public T Context { get; set; }
    }
}
