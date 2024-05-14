namespace DocumentManagement.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual List<Document>? Documents { get; set; }
        public virtual List<DocumentTemplate>? DocumentTemplates { get; set; }
    }
}
