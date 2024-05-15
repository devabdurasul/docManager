using DocumentManagement.Entities;
using DocumentManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTemplateController : GenericController<DocumentTemplate>
    {
        public DocumentTemplateController(IGenericService<DocumentTemplate> service) : base(service)
        {
        }
    }
}
