using DocumentManagement.Entities;
using DocumentManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : GenericController<Department>
    {
        public DepartmentController(IGenericService<Department> service) : base(service)
        {
        }
    }
}
