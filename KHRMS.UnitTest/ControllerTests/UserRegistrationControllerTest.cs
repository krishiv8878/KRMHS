using KHRMS.Controllers;
using KHRMS.Core;
using KHRMS.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.UnitTest.ControllerTests
{
    public class UserRegistrationControllerTest
    {
        public UserRegistrationControllerTest()
        {
                
        }


        [Fact]
        public void RegistrationReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IUserRegistrationService>();
            var controller = new UserRegistrationController(mock.Object);
            mock.Setup(x => x.GetRegistrationByUser(It.IsAny<UserRegistration>()));
            UserRegistration userregistration = new UserRegistration()
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                Email = "",
                MobileNumber = "",
                Address = "",
                Password = ""
            };
            var result = controller.Registration(userregistration);
            Assert.NotNull(result);
            Assert.Equal("", userregistration.FirstName);
        }
    }
}
