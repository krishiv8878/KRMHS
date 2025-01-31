using KHRMS.Core;

namespace KHRMS.Services
{
    public interface IEmployeeRoleMappingService
    {
        Task<bool> CreateEmployeeRoleMapping(EmployeeRoleMapping employeeRoleMapping);
        Task<IEnumerable<EmployeeRoleMapping>> GetAllEmployeeRoleMapping();
        Task<EmployeeRoleMapping> GetRoleMappingById(long employeeRoleMappingId);
        Task<bool> UpdateEmployeeRoleMapping(EmployeeRoleMapping employeeRoleMapping);
        Task<bool> DeleteEmployeeRoleMapping(long employeeRoleMappingId);
    }
}
