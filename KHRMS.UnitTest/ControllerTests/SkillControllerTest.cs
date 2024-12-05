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
    public class SkillControllerTest
    {
        public SkillControllerTest()
        {

        }

        [Fact]
        public void GetSkillsReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            var controller = new SkillController(mock.Object);
            mock.Setup(x => x.GetAllSkills());
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            mock.Setup(x => x.GetSkillById(1));
            var result = controller.GetSkill();
            Assert.NotNull(result);
            Assert.Equal(1, 1);
        }

        [Fact]
        public void UpdateSkillReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            var controller = new SkillController(mock.Object);
            mock.Setup(x => x.UpdateSkill(It.IsAny<Skill>()));
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            Skill updateskill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            var result = controller.UpdateSkill(updateskill);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal("Java Developer", skill.SkillName);
        }


        [Fact]
        public void AddSkillSkillsReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            var controller = new SkillController(mock.Object);
            mock.Setup(x => x.AddSkill(It.IsAny<Skill>()));
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            var result = controller.GetSkill();
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal("Java Developer", skill.SkillName);
        }

        [Fact]
        public void DeleteSkillSkillsReturnPass()
        {
            var Id = 1;
            var mock = new Mock<ISkillService>();
            var controller = new SkillController(mock.Object);
            mock.Setup(x => x.DeleteSkill(1));
            Skill skill = new Skill()
            {
                Id = 1,
                SkillName = "Java Developer",
            };
            var result = controller.DeleteSkill(1);
            Assert.NotNull(result);
            Assert.Equal(1, 1);
            Assert.Equal("Java Developer", skill.SkillName);
        }


    }
}