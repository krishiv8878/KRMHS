using KHRMS.Core;

namespace KHRMS.Services.Interfaces
{
    public interface IHolidayService
    {
        Task<bool> CreateHoliday(Holiday holiday);
        Task<IEnumerable<Holiday>> GetAllHolidays();
        Task<Holiday> GetHolidayById(int holidayId);
        Task<bool> UpdateHoliday(Holiday holiday);
        Task<bool> DeleteHoliday(long holidayId);
    }
}
