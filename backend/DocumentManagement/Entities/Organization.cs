namespace DocumentManagement.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<User>? Users { get; set; }
        public virtual List<Department>? Departments { get; set; }
    }
}
