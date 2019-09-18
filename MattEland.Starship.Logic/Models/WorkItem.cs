namespace MattEland.Starship.Logic.Models
{
    public class WorkItem
    {
        public WorkItem(int id)
        {
            Id = id;
        }

        public string Title { get; set; }
        public int Id { get; }
        public Department Department { get; set; }
        public int? AssignedCrewId { get; set; }
        public int CreatedByCrewId { get; set; }
        public int SystemId { get; set; }
        public WorkItemType WorkItemType { get; } = WorkItemType.Incident;
        public WorkItemStatus Status { get; set; } = WorkItemStatus.New;
        public Priority Priority { get; set; } = Priority.Normal;
    }
}