﻿using KHRMS.Core;
using Microsoft.AspNetCore.Http;

namespace KHRMS.Services
{
    public interface IEmployeeDocumentService
    {      
        Task<IEnumerable<EmployeeDocumentInfo>> GetAllAsync();
        Task<EmployeeDocumentInfo> GetByIdAsync(long id);
        Task AddAsync(EmployeeDocumentInfo document);
        Task DeleteAsync(long id);
        
    }
}
