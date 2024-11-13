using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class UserRegistrationRepository : GenericRepository<UserRegistration>, IUserRegistrationRepository
    {
        public UserRegistrationRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
