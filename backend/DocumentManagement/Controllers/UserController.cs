using DocumentManagement.Entities;
using DocumentManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : GenericController<User>
    {
        public UserController(IGenericService<User> service) : base(service)
        {
        }
    }
}
