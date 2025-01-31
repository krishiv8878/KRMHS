using AutoMapper.Configuration.Annotations;
using KHRMS.Core;
using KHRMS.Infrastructure;

namespace KHRMS.Services
{
    public class EmployeeRoleMappingService(IUnitOfWork unitOfWork) : IEmployeeRoleMappingService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> CreateEmployeeRoleMapping(EmployeeRoleMapping employeeRoleMapping)
        {
            if (employeeRoleMapping != null)
            {
                var employeeroleMapping = new EmployeeRoleMapping()
                {   
                    Id = employeeRoleMapping.Id,
                    RoleId = employeeRoleMapping.RoleId,
                    EmployeeId = employeeRoleMapping.EmployeeId,
                    CreatedDate = DateTime.Now,
                    IsActive = employeeRoleMapping.IsActive,
                    IsDeleted = employeeRoleMapping.IsDeleted,
                };
                await _unitOfWork.EmployeeRoleMappings.Add(employeeroleMapping);
                var result = _unitOfWork.Save();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteEmployeeRoleMapping(long employeeRoleMappingId)
        {
            if (employeeRoleMappingId > 0)
            {
                var employeeRoleMappingDetails = await _unitOfWork.EmployeeRoleMappings.GetById(employeeRoleMappingId);
                if (employeeRoleMappingDetails != null)
                {
                    employeeRoleMappingDetails.IsActive = false;
                    employeeRoleMappingDetails.IsDeleted = true;
                    _unitOfWork.EmployeeRoleMappings.Update(employeeRoleMappingDetails);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<EmployeeRoleMapping>> GetAllEmployeeRoleMapping()
        {
            var employeeRoleMapping = await _unitOfWork.EmployeeRoleMappings.GetAll();
            return employeeRoleMapping;
        }

        public async Task<EmployeeRoleMapping> GetRoleMappingById(long employeeRoleMappingId)
        {
            if(employeeRoleMappingId > 0)
            {

                var employeeRoleMappingDetails = await _unitOfWork.EmployeeRoleMappings.GetById(employeeRoleMappingId);
                if(employeeRoleMappingDetails != null)
                {
                    return employeeRoleMappingDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateEmployeeRoleMapping(EmployeeRoleMapping employeeRoleMapping)
        {
            if (employeeRoleMapping != null)
            {
                var employeeRoleMappingDetails = await _unitOfWork.EmployeeRoleMappings.GetById(employeeRoleMapping.Id);
                if (employeeRoleMappingDetails != null)
                {
                    employeeRoleMappingDetails.RoleId = employeeRoleMapping.RoleId;
                    employeeRoleMappingDetails.EmployeeId = employeeRoleMapping.EmployeeId;
                    employeeRoleMappingDetails.UpdatedDate = DateTime.Now;

                    _unitOfWork.EmployeeRoleMappings.Update(employeeRoleMappingDetails);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
