using KHRMS.Core;
using KHRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
