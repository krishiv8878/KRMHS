using KHRMS.Core;

namespace KHRMS.Services
{
    public class EmployeeDocumentService(IUnitOfWork unitOfWork) : IEmployeeDocumentService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;
            
        public async Task<IEnumerable<EmployeeDocumentInfo>> GetAllAsync()
        {
            return await _unitOfWork.EmployeementDocument.GetAll();
        }

      
        public async Task<EmployeeDocumentInfo> GetByIdAsync(long id)
        {
            return await _unitOfWork.EmployeementDocument.GetById(id);
        }
    
        public async Task AddAsync(EmployeeDocumentInfo document)
        {
            await _unitOfWork.EmployeementDocument.Add(document);
            _unitOfWork.Save();
        }
            
      
        public async Task DeleteAsync(long id)
        {
            var document = await _unitOfWork.EmployeementDocument.GetByIdAsync(id);
            if (document != null)
            {
                 _unitOfWork.EmployeementDocument.Delete(document);
                _unitOfWork.Save();
            }
        }
    }
}


