﻿using KHRMS.Core;
using Microsoft.EntityFrameworkCore;

namespace KHRMS.Infrastructure
{
    public class KHRMSContextClass : DbContext
    {
        public KHRMSContextClass(DbContextOptions<KHRMSContextClass> contextOptions) : base(contextOptions)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AssetsMaster> AssetsMasters { get; set; }
        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<ProjectMaster> ProjectMasters { get; set; }
        public DbSet<UserRegistration> UserRegistrations { get; set; }
    }
}
