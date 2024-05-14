namespace DocumentManagement.Entities
{
    public class DepartmentApproval : BaseEntity
    {
        public int Order { get; set; }
        public Department Department { get; set; }
    }
}
