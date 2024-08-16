using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
