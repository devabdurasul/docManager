using DocumentManagement.Entities;

namespace DocumentManagement.Services
{
    public class DepartmentService : GenericService<Department>, IGenericService<Department>
    {
        public DepartmentService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
