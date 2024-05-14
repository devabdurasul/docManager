namespace DocumentManagement.Entities
{
    public class Document : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public Guid CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentStatus Status { get; set; }
        public string FilePath { get; set; }

        public Guid AssociatedTemplateId { get; set; }
        public virtual DocumentTemplate AssociatedTemplate { get; set; }

        public Guid AssignedRouteId { get; set; }
        public virtual DepartamentDocumentSign AssignedRoute { get; set; }

        public virtual List<DocumentLog> Logs { get; set; }
    }
}
