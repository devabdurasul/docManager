using DocumentManagement.Entities;
using DocumentManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : GenericController<Document>
    {
        public DocumentController(IGenericService<Document> service) : base(service)
        {
        }

    }
}
