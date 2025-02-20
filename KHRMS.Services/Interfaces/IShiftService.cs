using KHRMS.Core;

namespace KHRMS.Services
{
    public interface IShiftService
    {
        Task<IEnumerable<ShiftMaster>> GetAllShiftsAsync();
        Task<ShiftMaster> GetShiftByIdAsync(long id);
        Task AddShiftAsync(ShiftMaster shiftMaster);
        Task UpdateShiftAsync(ShiftMaster shift);
        Task DeleteShiftAsync(long id);

    }

}
