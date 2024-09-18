using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class UserLoginRepository : GenericRepository<UserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(KHRMSContextClass dbcontext) : base(dbcontext)
        {
        }
    }
}
