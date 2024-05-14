namespace DocumentManagement.Entities
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public User CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentStatus Status { get; set; }
        public string FilePath { get; set; }
        public DocumentTemplate AssociatedTemplate { get; set; }
        public DepartamentDocumentSign AssignedRoute { get; set; }
        public ICollection<DocumentLog> Logs { get; set; }
    }
}
