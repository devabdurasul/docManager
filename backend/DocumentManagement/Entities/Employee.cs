namespace DocumentManagement.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Document> ViewableDocuments { get; set; }
        public virtual List<Document> ApprovedDocuments { get; set; }
        public virtual List<Document> RejectedDocuments { get; set; }
    }
}
