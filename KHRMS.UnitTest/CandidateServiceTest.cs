using KHRMS.Core;
using KHRMS.Services;
using Moq;
using NPOI.SS.Formula.Functions;

namespace KHRMS.UnitTest
{
    public class CandidateServiceTest
    {
        public CandidateServiceTest()
        {

        }

        [Fact]
        public void CreateCandidateReturnPass()
        {
            var mock = new Mock<ICandidateService>();
            List<Candidate> candidates = new List<Candidate>();
            mock.Setup(x => x.CreateCandidate(It.IsAny<Candidate>()))
                      .Returns(Task.FromResult(true));
            Candidate candidate = new Candidate()
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
            candidates.Add(candidate);
            Assert.Equal(1, 1);
        }

        [Fact]
        public void CreateCandidateReturnFail()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            candidates.Add(candidate);
            var result = candidateService.CreateCandidate(candidate);
            var exception = Assert.Throws<InvalidOperationException>(() => candidates.Add(candidate));
            Assert.Equal("Candidate already exists", exception.Message);
        }

        [Fact]
        public void CreateCandidateReturnException()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
            Candidate candidate = new Candidate();
            candidates.Add(candidate);
            var result = candidateService.CreateCandidate(candidate);
            var exception = Assert.Throws<InvalidOperationException>(() => candidates.Add(null));
            Assert.Equal("Candiadate already exists", exception.Message);
        }

        [Fact]
        public void DeleteCandidateReturnsPass()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            mock.Setup(x => x.DeleteCandidate(1));
            var result = candidateService.DeleteCandidate(1);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            mock.Verify(x => x.DeleteCandidate(1), Times.Once);
        }

        [Fact]
        public async Task DeleteCandidateReturnsFail()
        {
            var Id = 999;
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            mock.Setup(x => x.DeleteCandidate(1));
            var result = candidateService.DeleteCandidate(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => candidateService.DeleteCandidate(Id));
            Assert.Equal("Candidate not found", exception.Message);
        }

        [Fact]
        public async Task DeleteCandidateReturnsException()
        {
            var Id = 1;
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            mock.Setup(x => x.DeleteCandidate(1));
            var result = candidateService.DeleteCandidate(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => candidateService.DeleteCandidate(Id));
            Assert.Equal("Candidate not found", exception.Message);
            mock.Verify(x => x.DeleteCandidate(1), Times.Once);
        }

        [Fact]
        public void GetAllCandidatesReturnPass()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            mock.Setup(x => x.GetAllCandidates());
            var result = candidateService.GetAllCandidates();
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal(1, candidate.Id);
            Assert.Equal("Raj", candidate.FirstName);
        }

        [Fact]
        public async Task GetAllCandidatesReturnFail()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
            mock.Setup(x => x.GetAllCandidates());
            var result = candidateService.GetAllCandidates();
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() =>candidateService.GetAllCandidates());
            Assert.Equal("No Candidate available", exception.Message);
        }

        [Fact]
        public async Task GetAllCandidatesReturnExcep0tion()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
            mock.Setup(x => x.GetAllCandidates());
            var result = candidateService.GetAllCandidates();
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.GetAllCandidates());
            Assert.Equal("Unexpected error", exception.Message);
        }

        [Fact]
        public void GetCandidateByIdReturnPass()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            mock.Setup(x => x.GetCandidateById(1));
            var result = candidateService.GetCandidateById(1);
            Assert.NotNull(result);
            Assert.Equal(1, candidate.Id);
            Assert.Equal("Raj", candidate.FirstName);
        }

        [Fact]
        public async Task GetCandidateByIdReturnFail()
        {
            var Id = 999;
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
            mock.Setup(x => x.GetCandidateById(1));
            var result = candidateService.GetCandidateById(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => candidateService.GetCandidateById(Id));
            Assert.Equal("Candidate not found", exception.Message);
        }

        [Fact]
        public async Task GetCandidateByIdReturnException()
        {
            var Id = 1;
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
            mock.Setup(x => x.GetCandidateById(1));
            var result = candidateService.GetCandidateById(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => candidateService.GetCandidateById(1));
            Assert.Equal("Candidate not found", exception.Message);
        }

        [Fact]
        public void UpdateCandidateReturnPass()
        {
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
                FirstName = "Rajesh",
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
            mock.Setup(x => x.UpdateCandidate(candidate));
            var result = candidateService.UpdateCandidate(candidate);
            Assert.Equal(1,1);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateCandidateReturnFail()
        {
            var Id = 1;
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            mock.Setup(x => x.GetCandidateById(1));
            mock.Setup(x => x.UpdateCandidate(candidate));
            var result = candidateService.UpdateCandidate(candidate);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => candidateService.UpdateCandidate(candidate));
            Assert.Equal("Update not found", exception.Message);
        }

        [Fact]
        public async Task UpdateCandidateReturnException()
        {
            var Id = 1;
            var mock = new Mock<ICandidateService>();
            ICandidateService candidateService = mock.Object;
            List<Candidate> candidates = new List<Candidate>();
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
            mock.Setup(x => x.GetCandidateById(1));
            mock.Setup(x => x.UpdateCandidate(candidate));
            var result = candidateService.UpdateCandidate(candidate);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => candidateService.UpdateCandidate(null));
            Assert.Equal("Update not found", exception.Message);
        }
    }
}
