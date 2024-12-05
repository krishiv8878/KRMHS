using KHRMS.Core;
using KHRMS.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.UnitTest.ServiceTests
{
    public class SkillServiceTest
    {
        public SkillServiceTest()
        {
            
        }


        [Fact]
        public void AddSkillReturnPass()
        {
            var mock = new Mock<ISkillService>();
            List<Skill> skills = new List<Skill>();
            mock.Setup(x => x.AddSkill(It.IsAny<Skill>()))
                        .Returns(Task.FromResult(true));
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            skills.Add(skill);
            Assert.Equal(1, 1);
        }


        [Fact]
        public void AddSkillReturnFail()
        {
            var mock = new Mock<ISkillService>();
            List<Skill> skills = new List<Skill>();
            ISkillService skillService = mock.Object;
            mock.Setup(x => x.AddSkill(It.IsAny<Skill>()))
                        .Returns(Task.FromResult(true));
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            skills.Add(skill);
            var exception = Assert.Throws<InvalidOperationException>(() => skills.Add(skill));
            Assert.Equal("Skill already exists", exception.Message);
        }


        [Fact]
        public void AddSkillReturnException()
        {
            var mock = new Mock<ISkillService>();
            List<Skill> skills = new List<Skill>();
            ISkillService skillService = mock.Object;
            mock.Setup(x => x.AddSkill(It.IsAny<Skill>()))
                        .Returns(Task.FromResult(true));
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            skills.Add(skill);
            var exception = Assert.Throws<InvalidOperationException>(() => skills.Add(null));
            Assert.Equal("Skill already exists", exception.Message);
        }

        [Fact]
        public void DeleteSkillReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.DeleteSkill(Id));
            var result = skillService.DeleteSkill(Id);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            mock.Verify(x => x.DeleteSkill(1), Times.Once);
        }

        [Fact]
        public async Task DeleteSkillReturnFail()
        {
            var Id = 999;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.DeleteSkill(Id));
            var result = skillService.DeleteSkill(Id);
            mock.Verify(x => x.DeleteSkill(1), Times.Once);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => skillService.DeleteSkill(Id));
            Assert.Equal("Skill not found", exception.Message);
        }

        [Fact]
        public async Task DeleteSkillReturnException()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.DeleteSkill(Id));
            var result = skillService.DeleteSkill(Id);
            mock.Verify(x => x.DeleteSkill(1), Times.Once);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => skillService.DeleteSkill(Id));
            Assert.Equal("Skill not found", exception.Message);
        }

        [Fact]
        public void GetAllSkillsReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.GetAllSkills());
            var result = skillService.GetAllSkills();
            Assert.NotNull(result);
            Assert.Equal(1, skill.Id);
            Assert.Equal("Java Developer", skill.SkillName);
        }

        [Fact]
        public async Task GetAllSkillsReturnFail()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill();
            mock.Setup(x => x.GetAllSkills());
            var result = skillService.GetAllSkills();
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => skillService.GetAllSkills());
            Assert.Equal("No Skill available", exception.Message);
        }


        [Fact]
        public async Task GetAllSkillsReturnException()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill();
            mock.Setup(x => x.GetAllSkills());
            var result = skillService.GetAllSkills();
            var exception = await Assert.ThrowsAsync<Exception>(() => mock.Object.GetAllSkills());
            Assert.Equal("Unexpected error", exception.Message);
        }

        [Fact]
        public void GetSkillByIdReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.GetSkillById(1));
            var result = skillService.GetSkillById(1);
            Assert.NotNull(result);
            Assert.Equal(1, skill.Id);
            Assert.Equal("Java Developer", skill.SkillName);
        }

        [Fact]
        public async Task GetSkillByIdReturnFail()
        {
            var Id = 999;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill();
            mock.Setup(x => x.GetSkillById(1));
            var result = skillService.GetSkillById(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => skillService.GetSkillById(Id));
            Assert.Equal("LeaveType not found", exception.Message);
        }

        [Fact]
        public async Task GetSkillByIdReturnException()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill();
            mock.Setup(x => x.GetSkillById(1));
            var result = skillService.GetSkillById(1);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => skillService.GetSkillById(Id));
            Assert.Equal("LeaveType not found", exception.Message);
        }


        [Fact]
        public void UpdateSkillReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            Skill updateskill = new Skill()
            {
                Id = 1,
                SkillName = "Angular Developer",
            };
            mock.Setup(x => x.GetSkillById(1));
            var result = skillService.UpdateSkill(skill);
            Assert.NotNull(result);
            Assert.Equal(1,1);
        }


        [Fact]
        public async Task UpdateSkillReturnFail()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.GetSkillById(1));
            var result = skillService.UpdateSkill(skill);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => skillService.UpdateSkill(skill));
            Assert.Equal("Update not found", exception.Message);
        }

        [Fact]
        public async Task UpdateSkillReturnException()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            ISkillService skillService = mock.Object;
            List<Skill> skills = new List<Skill>();
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.GetSkillById(1));
            var result = skillService.UpdateSkill(skill);
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => skillService.UpdateSkill(null));
            Assert.Equal("Update not found", exception.Message);
        }

    }
}
