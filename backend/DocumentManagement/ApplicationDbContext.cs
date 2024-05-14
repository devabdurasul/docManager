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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable lazy loading
            //optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(u => u.Organization).WithMany(o => o.Users).HasForeignKey(s => s.OrganizationId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Employee>().HasOne(u => u.Department).WithMany(o => o.Employees).HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DocumentTemplate>().HasOne(u => u.CreatedBy).WithMany(o => o.DocumentTemplates).HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Document>().HasOne(u => u.CreatedBy).WithMany(o => o.Documents).HasForeignKey(s => s.CreatedById).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Document>().HasOne(u => u.AssociatedTemplate).WithMany(o => o.Documents).HasForeignKey(s => s.AssociatedTemplateId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Document>().HasOne(u => u.AssignedRoute).WithMany(o => o.Documents).HasForeignKey(s => s.AssignedRouteId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepartmentApproval>().HasOne(u => u.Department).WithMany(o => o.DepartmentApprovals).HasForeignKey(d => d.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DepartamentDocumentSign>().HasOne(u => u.AssignedDepartment).WithMany(o => o.DepartamentDocumentSigns).HasForeignKey(d => d.AssignedDepartmentId).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
