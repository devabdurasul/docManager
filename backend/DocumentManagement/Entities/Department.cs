namespace DocumentManagement.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual List<DepartmentApproval> DepartmentApprovals { get; set; }
        public virtual List<DepartamentDocumentSign> DepartamentDocumentSigns { get; set; }
        public virtual List<DocumentTemplate>? Templates { get; set; }
        public virtual List<Employee>? Employees { get; set; }
    }
}
