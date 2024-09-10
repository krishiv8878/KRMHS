using KHRMS.Core;
using KHRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Services.Interfaces
{
    public interface ISkillService
    {
        Task<bool> AddSkill(Skill skill);
        Task<IEnumerable<Skill>> GetAllSkills();
        Task<Skill> GetSkillById(int skillId);
        Task<bool> UpdateSkill(Skill skill);
        Task<bool> DeleteSkill(long skillId);

    }
}
