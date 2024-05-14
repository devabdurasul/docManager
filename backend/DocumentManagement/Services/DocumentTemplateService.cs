using DocumentManagement.Entities;

namespace DocumentManagement.Services
{
    public class DocumentTemplateService : GenericService<DocumentTemplate>, IGenericService<DocumentTemplate>
    {
        public DocumentTemplateService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
