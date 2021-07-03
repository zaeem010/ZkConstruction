using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZkConstruction.Models;
using Microsoft.AspNetCore.Identity;
namespace ZkConstruction.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<EProject> EProject { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Subsection> SubSection { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<AccountHead> AccountHead { get; set; }
        public DbSet<FirstLevel> FirstLevel { get; set; }
        public DbSet<SecondLevel> SecondLevel { get; set; }
        public DbSet<ThirdLevel> ThirdLevel { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<DEmployee> DEmployee { get; set; }
        public DbSet<Contractor> Contractor { get; set; }
        public DbSet<EProjectchild> EPchild { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<ProjectAssign> ProjectAssign { get; set; }
        public DbSet<Assignchild> Assignchild { get; set; }
        public DbSet<Sitevisit> Sitevisit { get; set; }
        public DbSet<SitevisitImage> SitevisitImage { get; set; }
        public DbSet<DailyShedule> DailyShedule { get; set; }
        public DbSet<DailySheduleChild> DailySheduleChild { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<STOMaster> STOMaster { get; set; }
        public DbSet<STODetail> STODetail { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
        public DbSet<STDMaster> STDMaster { get; set; }
        public DbSet<STDDetail> STDDetail { get; set; }
        public DbSet<Worksheet> Worksheet { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<EmployeeAssigned> EmployeeAssigned { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
