namespace DocumentManagement.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public Department Department { get; set; }
        public ICollection<Document> ViewableDocuments { get; set; }
        public ICollection<Document> ApprovedDocuments { get; set; }
        public ICollection<Document> RejectedDocuments { get; set; }
    }
}
