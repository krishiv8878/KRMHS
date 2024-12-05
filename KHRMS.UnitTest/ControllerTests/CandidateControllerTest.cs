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
    public class CandidateControllerTest
    {
        public CandidateControllerTest()
        {

        }
    

     [Fact]
        public void AddCandidateReturnPass()
        {
            var mock = new Mock<ICandidateService>();
            mock.Setup(x => x.CreateCandidate(It.IsAny<Candidate>()));
            var controller = new CandidateController(mock.Object);
            var Id = 1;
            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Raj",
                LastName = "Prajapati",
                EmailAddress = "user@example.com",
                MobileNumber = "9876543210",
                TotalExperience = "string",
                RelevantExperience = "string",
                CurrentSalary = 0,
                ExpectedSalary = 0,
                NoticePeriod = 0
            };
            var result = controller.AddCandidate(candidate);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal("Raj", candidate.FirstName);
        }

        [Fact]
        public void GetCandidatesReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ICandidateService>();
            mock.Setup(x => x.GetAllCandidates());
            var controller = new CandidateController(mock.Object);
            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Raj",
                LastName = "Prajapati",
                EmailAddress = "user@example.com",
                MobileNumber = "9876543210",
                TotalExperience = "string",
                RelevantExperience = "string",
                CurrentSalary = 0,
                ExpectedSalary = 0,
                NoticePeriod = 0
            };
            var result = controller.GetCandidates();
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal("Raj", candidate.FirstName);
        }

        [Fact]
        public void UpdateCandidateReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ICandidateService>();
           // mock.Setup(x => x.UpdateCandidate());
            var controller = new CandidateController(mock.Object);
            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Raj",
                LastName = "Prajapati",
                EmailAddress = "user@example.com",
                MobileNumber = "9876543210",
                TotalExperience = "string",
                RelevantExperience = "string",
                CurrentSalary = 0,
                ExpectedSalary = 0,
                NoticePeriod = 0
            };
            var updatecandidate = new Candidate
            {
                Id = 1,
                FirstName = "Anil",
                LastName = "Prajapati",
                EmailAddress = "user@example.com",
                MobileNumber = "9876543210",
                TotalExperience = "string",
                RelevantExperience = "string",
                CurrentSalary = 0,
                ExpectedSalary = 0,
                NoticePeriod = 0
            };
            mock.Setup(x => x.GetCandidateById(1));
            var result = controller.UpdateCandidate(candidate);
            Assert.NotNull(result);
            Assert.Equal(1, candidate.Id);
            Assert.Equal("Raj", candidate.FirstName);
        }

        [Fact]
        public void DeleteCandidateReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ICandidateService>();
            mock.Setup(x => x.GetAllCandidates());
            var controller = new CandidateController(mock.Object);
            var candidate = new Candidate
            {
                Id = 1,
                FirstName = "Raj",
                LastName = "Prajapati",
                EmailAddress = "user@example.com",
                MobileNumber = "9876543210",
                TotalExperience = "string",
                RelevantExperience = "string",
                CurrentSalary = 0,
                ExpectedSalary = 0,
                NoticePeriod = 0
            };
            var result = controller.DeleteCandidate(1);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            mock.Verify(x => x.DeleteCandidate(1), Times.Once);
        }


    }
}
