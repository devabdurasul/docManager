using DocumentManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocumentManagement
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DepartamentDocumentSign> DepartamentDocumentSigns { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentApproval> DepartmentApprovals { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentLog> DocumentLogs { get; set; }
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
