﻿
using KHRMS.Core;

namespace KHRMS.Services
{
    public interface IEmployeePaymentInfoService
    {

        Task<IEnumerable<EmployeePaymentInfo>> GetAllAsync();
        Task<EmployeePaymentInfo?> GetByIdAsync(long id);
        Task AddAsync(EmployeePaymentInfo entity);
        Task UpdateAsync(EmployeePaymentInfo entity);
        Task DeleteAsync(long id);
    }
}




