using KHRMS.Core;

namespace KHRMS.Services
{
    public interface IUserRegistrationService
    {
        Task<bool> GetRegistrationByUser(UserRegistration userRegistration);

       // Task<bool> GetUserRegistration(string email, string Password);
    }
}
