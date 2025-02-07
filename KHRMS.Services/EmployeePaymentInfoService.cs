using KHRMS.Core;
using KHRMS.Services;

namespace KHRMS.Services
{

    public class EmployeePaymentInfoService(IUnitOfWork unitOfWork) : IEmployeePaymentInfoService
    {
        public IUnitOfWork _unitOfWork = unitOfWork;



        public async Task<IEnumerable<EmployeePaymentInfo>> GetAllAsync()
            => await _unitOfWork.EmployeePaymentInfo.GetAll();

        public async Task<EmployeePaymentInfo?> GetByIdAsync(long id)
            => await _unitOfWork.EmployeePaymentInfo.GetById(id);

        public async Task AddAsync(EmployeePaymentInfo entity)
        {

            await _unitOfWork.EmployeePaymentInfo.Add(entity);

        }

        public Task UpdateAsync(EmployeePaymentInfo entity)
        {


            _unitOfWork.EmployeePaymentInfo.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(long id)
        {

            unitOfWork.EmployeePaymentInfo.DeleteAsync(id);
            return Task.CompletedTask;

        }



    }

}