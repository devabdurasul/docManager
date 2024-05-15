using DocumentManagement.Entities;

namespace DocumentManagement.Services
{
    public class UserService : GenericService<User>, IGenericService<User>
    {
        public UserService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
