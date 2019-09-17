namespace MattEland.Starship.Logic
{
    public class WorkItem
    {
        public WorkItem(int createdByCrewId, int systemId, string title, Department department)
        {
            CreatedByCrewId = createdByCrewId;
            SystemId = systemId;
            Title = title;
            Department = department;
        }

        public string Title { get; }
        public int Id { get; }
        public Department Department { get; }
        public int? AssignedCrewId { get; set; }
        public int CreatedByCrewId { get; }
        public int SystemId { get; }
        public WorkItemType WorkItemType { get; } = WorkItemType.Incident;
        public WorkItemStatus Status { get; set; } = WorkItemStatus.New;
    }
}