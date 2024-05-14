using DocumentManagement.Entities;

namespace DocumentManagement.Services
{
    public class DocumentService : GenericService<Document>, IGenericService<Document>
    {
        public DocumentService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
