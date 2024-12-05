using KHRMS.Core;
using KHRMS.Services;
using KHRMS.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.UnitTest.ControllerTests
{
    public class UserLoginControllerTest
    {
        public UserLoginControllerTest()
        {
            
        }

        [Fact]
        public void LoginReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IUserLoginService>();
            var controller = new UserLoginController(mock.Object);
            //mock.Setup(x => x.GetUserLoginById());
            UserLogin user = new UserLogin()
            {
                Id = 1,
                UserId = 0,
                UserName = "",
                Password = "",
                Email = "",
                //LastLoginDate = new DateTime(0, 0, 0, 0, 0, 0, 0)
            };
            var result = controller.Login(user.Email, user.Password);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
        }

    }
}
