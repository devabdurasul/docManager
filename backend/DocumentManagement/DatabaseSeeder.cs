
using DocumentManagement.Entities;

namespace DocumentManagement
{
    public static class DatabaseSeeder
    {
        internal static async Task SeedAsync(ApplicationDbContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            var organization = new Organization()
            {
                Name = "SRP",
            };
            context.Organizations.Add(organization);
            await context.SaveChangesAsync();

            // Create Users
            var adminUser = new User
            {
                Name = "Sanjar",
                Username = "admin",
                Password = "admin123",
                Email = "admin@example.com",
                Organization = organization,
                Role = UserRole.Administrator
            };
            var operatorUser = new User
            {
                Name = "Shahzod",
                Username = "operator",
                Password = "operator123",
                Email = "operator@example.com",
                Organization = organization,
                Role = UserRole.Operator
            };
            var employeeUser = new User
            {
                Name = "Sardor",
                Username = "employee",
                Password = "employee123",
                Email = "employee@example.com",
                Organization = organization,
                Role = UserRole.Employee
            };
            context.Users.AddRange(adminUser, operatorUser, employeeUser);
            await context.SaveChangesAsync();

            var department = new Department()
            {
                Name = "Bugalteriya",
                Organization = organization
            };

            // Create Document Templates
            var template1 = new DocumentTemplate
            {
                Title = "Template 1",
                Content = "Template content 1",
                CreatedBy = adminUser,
                DateCreated = DateTime.UtcNow
            };
            var template2 = new DocumentTemplate
            {
                Title = "Template 2",
                Content = "Template content 2",
                CreatedBy = adminUser,
                DateCreated = DateTime.UtcNow
            };
            context.DocumentTemplates.AddRange(template1, template2);
            await context.SaveChangesAsync();


            // Create Departments
            var department1 = new Department
            {
                Name = "Department 1",
                Organization = organization,
                Templates = new List<DocumentTemplate> { }
            };
            var department2 = new Department
            {
                Name = "Department 2",
                Organization = organization,
                Templates = new List<DocumentTemplate> { }
            };
            context.Departments.AddRange(department1, department2);
            await context.SaveChangesAsync();

            // Create Department Approvals
            var departmentApproval1 = new DepartmentApproval
            {
                Order = 1,
                Department = department1
            };
            var departmentApproval2 = new DepartmentApproval
            {
                Order = 2,
                Department = department2
            };
            context.DepartmentApprovals.AddRange(departmentApproval1, departmentApproval2);
            await context.SaveChangesAsync();

            // Create Document Flow Routes
            var route1 = new DepartamentDocumentSign
            {
                AssignedDepartment = department,
                Comment = "Route 1 description",
                Status = RouteStatus.Active
            };
            var route2 = new DepartamentDocumentSign
            {
                AssignedDepartment = department2,
                Comment = "Route 2 description",
                Status = RouteStatus.Active
            };
            context.DepartamentDocumentSigns.AddRange(route1, route2);
            await context.SaveChangesAsync();

            // Create Documents
            var document1 = new Document
            {
                Name = "Document 1",
                Content = "Document content 1",
                CreatedBy = adminUser,
                DateCreated = DateTime.UtcNow,
                Status = DocumentStatus.Draft,
                AssociatedTemplate = template1,
                AssignedRoute = route1
            };
            var document2 = new Document
            {
                Name = "Document 2",
                Content = "Document content 2",
                CreatedBy = adminUser,
                DateCreated = DateTime.UtcNow,
                Status = DocumentStatus.Draft,
                AssociatedTemplate = template2,
                AssignedRoute = route2
            };
            context.Documents.AddRange(document1, document2);
            await context.SaveChangesAsync();

            template1.AssignedDepartments = new List<DepartmentApproval> { departmentApproval1, departmentApproval2 };
            template2.AssignedDepartments = new List<DepartmentApproval> { departmentApproval2, departmentApproval1 };
            await context.SaveChangesAsync();

            // Create Document Logs
            var log1 = new DocumentLog
            {
                Timestamp = DateTime.UtcNow,
                Note = "Log 1"
            };
            var log2 = new DocumentLog
            {
                Timestamp = DateTime.UtcNow,
                Note = "Log 2"
            };
            document1.Logs = new List<DocumentLog> { log1 };
            document2.Logs = new List<DocumentLog> { log2 };
            await context.SaveChangesAsync();
        }
    }

}
