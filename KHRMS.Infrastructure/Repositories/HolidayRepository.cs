using KHRMS.Core.Interfaces;
using KHRMS.Core;

namespace KHRMS.Infrastructure.Repositories
{
    public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(KHRMSContextClass dbcontext) : base(dbcontext)
        {
        }
    }
}
