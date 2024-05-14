namespace DocumentManagement.Entities
{
    public class DocumentTemplate : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public User CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<DepartmentApproval> AssignedDepartments { get; set; }
    }
}
