namespace DocumentManagement.Entities
{
    public class DocumentTemplate : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<Document> Documents { get; set; }
        public virtual List<DepartmentApproval> AssignedDepartments { get; set; }
    }
}
