using KHRMS.Core;
namespace KHRMS.Services.Interfaces
{
    public interface IDesignationService
    {
        Task<bool> CreateDesignation(Designation designation);
        Task<IEnumerable<Designation>> GetAllDesignations();
        Task<Designation> GetDesignationById(int designationId);
        Task<bool> UpdateDesignation(Designation designation);
        Task<bool> DeleteDesignation(long designationId);
     }
}
