using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
    {
        public HolidayRepository(KHRMSContextClass dbcontext) : base(dbcontext)
        {
        }
    }
}
