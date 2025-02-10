﻿
using KHRMS.Core;

namespace KHRMS.Services.Request
{
    public class EmployeesDTO : KHRMSBase
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public int DesignationId { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string? Gender { get; set; }
        public string? CurrentAddress { get; set; }

        public string? PermanentAddress { get; set; }
        public long EmployeeCode { get; set; }

        public List<String>? RolesName { get; set; }
    }
}
