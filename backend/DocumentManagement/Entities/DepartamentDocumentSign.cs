namespace DocumentManagement.Entities
{
    public class DepartamentDocumentSign : BaseEntity
    {
        public Department AssignedDepartment { get; set; }
        public string Comment { get; set; }
        public RouteStatus Status { get; set; }
    }
}
