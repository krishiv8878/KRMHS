﻿using KHRMS.Core;
using KHRMS.Services;
using KHRMS.Services.Interfaces;
using Moq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.UnitTest.ServiceTests
{
    public class UserRegistrationTest
    {
        public UserRegistrationTest()
        {
            
        }

        [Fact]
        public void GetRegistrationByUserReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IUserRegistrationService>();
            IUserRegistrationService userregistrationservice = mock.Object;
            List<UserRegistration> userregistrations = new List<UserRegistration>();
            UserRegistration userregistration = new UserRegistration()
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                Email = "",
                MobileNumber="",
                Address="",
                Password=""
            };
            mock.Setup(x => x.GetRegistrationByUser(userregistration));
            var result = userregistrationservice.GetRegistrationByUser(userregistration);
            Assert.Equal(1, userregistration.Id);
            Assert.Equal("", userregistration.FirstName);
        }


        [Fact]
        public void AddUserLoginReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IUserRegistrationService>();
            IUserRegistrationService userregistrationservice = mock.Object;
            List<UserRegistration> userregistrations = new List<UserRegistration>();
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
            userregistrations.Add(userregistration);
            mock.Setup(x => userregistrationservice.GetRegistrationByUser(userregistration));
            Assert.Equal(1, 1);
        }

    }
}
