using KHRMS.Core;
using KHRMS.Infrastructure;

namespace KHRMS.Services
{
    public class DocumentMasterServicee(IUnitOfWork unitOfWork) : IDocumentMasterService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;

       
        public async Task<IEnumerable<DocumentMaster>> GetAllAsync()
        {
            var Getalldocuments = await _unitOfWork.DocumentMaster.GetAll();
            return Getalldocuments;
        }

        public async Task<DocumentMaster> GetByIdAsync(long id)
        {
            var Getalldocumentsbyid = await _unitOfWork.DocumentMaster.GetById(id);
            return Getalldocumentsbyid;
        }

        public async Task AddAsync(DocumentMaster document)
        {
            
            await _unitOfWork.DocumentMaster.Add(document);
            _unitOfWork.Save();

        }

        public  Task UpdateAsync(DocumentMaster document)
        {
            _unitOfWork.DocumentMaster.Update(document);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public  Task DeleteAsync(long id)
        {
            _unitOfWork.DocumentMaster.DeleteAsync(id);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }
    }
}


