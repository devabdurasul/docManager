namespace DocumentManagement.Entities
{
    public class DepartamentDocumentSign : BaseEntity
    {
        public Guid AssignedDepartmentId { get; set; }
        public virtual Department AssignedDepartment { get; set; }
        public virtual List<Document> Documents { get; set; }
        public string Comment { get; set; }
        public RouteStatus Status { get; set; }
    }
}
