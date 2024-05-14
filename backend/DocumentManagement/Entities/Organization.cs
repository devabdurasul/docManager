namespace DocumentManagement.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User>? Users { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}
