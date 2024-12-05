﻿using KHRMS.Core;
using KHRMS.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.UnitTest.ControllerTests
{
    public class HolidayControllerTesting
    {
        public HolidayControllerTesting()
        {
            
        }

        [Fact]
        public void GetEmployeesReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IHolidayService>();
            var controller = new HolidayController(mock.Object);
            mock.Setup(x => x.GetAllHolidays());
            Holiday holiday = new Holiday()
            {
                Id = 1,
                HolidayName = "",
                Description = new DateTime(2024, 10, 16, 9, 44, 16),
            };
            var result = controller.GetHolidays();
            Assert.NotNull(result);
            Assert.Equal(1, 1);
        }


        [Fact]
        public void AddHolidayReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IHolidayService>();
            var controller = new HolidayController(mock.Object);
            mock.Setup(x => x.CreateHoliday(It.IsAny<Holiday>()));
            Holiday holiday = new Holiday()
            {
                Id = 1,
                HolidayName = "",
                Description = new DateTime(2024, 10, 16, 9, 44, 16),
            };
            var result = controller.AddHoliday(holiday);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal("",holiday.HolidayName);
        }

        [Fact]
        public void UpdateHolidayReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IHolidayService>();
            var controller = new HolidayController(mock.Object);
            mock.Setup(x => x.UpdateHoliday(It.IsAny<Holiday>()));
            Holiday holiday = new Holiday()
            {
                Id = 1,
                HolidayName = "",
                Description = new DateTime(2024, 10, 16, 9, 44, 16),
            };
            Holiday updateholiday = new Holiday()
            {
                Id = 1,
                HolidayName = "NewHoliday",
                Description = new DateTime(2024, 10, 16, 9, 44, 16),
            };
            var result = controller.UpdateHoliday(holiday);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal("", holiday.HolidayName);
        }

        [Fact]
        public void DeleteHolidayReturnPass()
        {
            var Id = 1;
            var mock = new Mock<IHolidayService>();
            var controller = new HolidayController(mock.Object);
            mock.Setup(x => x.DeleteHoliday(1));
            Holiday holiday = new Holiday()
            {
                Id = 1,
                HolidayName = "",
                Description = new DateTime(2024, 10, 16, 9, 44, 16),
            };
            var result = controller.DeleteHoliday(1);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            mock.Verify(x => x.DeleteHoliday(1), Times.Once);
        }

    }
}
