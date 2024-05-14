namespace DocumentManagement.Entities
{
    public class DepartmentApproval : BaseEntity
    {
        public int Order { get; set; }

        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
