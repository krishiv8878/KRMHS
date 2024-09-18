using KHRMS.Core;

namespace KHRMS.Services
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
