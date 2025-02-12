using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class EmployeeDocumentRepository : GenericRepository<EmployeeDocumentInfo>, IEmployeeDocumentRepository
    {
        public EmployeeDocumentRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}

