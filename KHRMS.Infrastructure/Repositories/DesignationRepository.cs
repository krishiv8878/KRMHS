using KHRMS.Core;
using KHRMS.Core.Interfaces;
using KHRMS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHRMS.Infrastructure.Repositories
{
    public class DesignationRepository : GenericRepository<Designation>, IDesignationRepository
    {
        public DesignationRepository(KHRMSContextClass dbContext) : base(dbContext)
        {

        }
    }
}
