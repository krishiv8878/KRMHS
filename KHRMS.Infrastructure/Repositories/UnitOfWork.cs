﻿using KHRMS.Core;

namespace KHRMS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KHRMSContextClass _dbContext;
        public ICandidateRepository Candidates { get; }
        public ISkillRepository Skills { get; }
        public IDesignationRepository Designations { get; }

        public IHolidayRepository Holidays { get; }

        public IEmployeeRepository Employees { get; }

        public ILeaveRepository LeaveType { get; }

        public IAssetsMasterRepository AssetsMasters { get; }

        public IUserLoginRepository UserLogins { get; }

        public IProjectMasterRepository ProjectMasters { get; }
        public IUserRegistrationRepository UserRegistrations { get; }
        
        public IRoleMasterRepository RoleMaster {  get; }
        public IEmployeeRoleMappingRepository EmployeeRoleMappings { get; }

        public IAttendanceRequestRepository AttendanceRequests { get; }

        public IEmployeeAttendanceRepository EmployeeAttendance  { get; }

        public IEmployeePaymentInfoRepository EmployeePaymentInfo { get; }

        public IDocumentMasterRepository DocumentMaster { get; }
        public UnitOfWork(KHRMSContextClass dbContext,
                            ICandidateRepository candidateRepository,
                            ISkillRepository skillRepository,
                            IDesignationRepository designationRepository,
                            IHolidayRepository holidayRepository,
                            IEmployeeRepository employeesRepository,
                            IAssetsMasterRepository assetsMasterRepository,
                            ILeaveRepository leaveRepository,
                            IUserLoginRepository userLoginRepository,
                            IProjectMasterRepository projectMasters,
                            IUserRegistrationRepository registrationRepository,
                            IRoleMasterRepository roleMaster,
                            IEmployeeRoleMappingRepository employeeRoleMappings,
                            IAttendanceRequestRepository attendanceRequestRepository,
                            IEmployeeAttendanceRepository employeeAttendanceRepository,
                            IEmployeePaymentInfoRepository employeePaymentInfo,
                            IDocumentMasterRepository employeeDocumentInfo)
        {
            _dbContext = dbContext;
            Candidates = candidateRepository;
            Skills = skillRepository;
            Designations = designationRepository;
            Employees = employeesRepository;
            Holidays = holidayRepository;
            AssetsMasters = assetsMasterRepository;
            LeaveType = leaveRepository;
            UserLogins = userLoginRepository;
            ProjectMasters = projectMasters;
            UserRegistrations = registrationRepository;
            RoleMaster = roleMaster;
            EmployeeRoleMappings = employeeRoleMappings;
            AttendanceRequests = attendanceRequestRepository;
            EmployeeAttendance = employeeAttendanceRepository;
            EmployeePaymentInfo = employeePaymentInfo;
            DocumentMaster = employeeDocumentInfo;


        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
