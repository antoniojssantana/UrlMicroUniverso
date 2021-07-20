using url.business.Interfaces.Repository;
using url.business.Models;
using url.data.Context;

namespace url.data.Repository
{
    public class UserBaseRepository : Repository<UserBaseModel>, IUserBaseRepository
    {
        public UserBaseRepository(URLDbContext dbContext) : base(dbContext)
        {
        }
    }
}