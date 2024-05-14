namespace DocumentManagement.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Organization Organization { get; set; }
        public ICollection<DocumentTemplate>? Templates { get; set; }
    }
}
