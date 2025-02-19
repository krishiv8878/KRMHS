using KHRMS.Core;


namespace KHRMS.Infrastructure
{
    public class ShiftRepository : GenericRepository<ShiftMaster> , IShiftRepository
    {
        public ShiftRepository(KHRMSContextClass dbContext) : base(dbContext)
        {
        }

    }
}
