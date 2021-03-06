using IkeMtz.NRSRx.Core.EntityFramework;
using NurseCron.Employees.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace NurseCron.Employees.WebApi.Data
{
  public partial class EmployeesContext : AuditableDbContext, IEmployeesContext
  {
    public EmployeesContext(DbContextOptions<EmployeesContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options, httpContextAccessor)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }


    public virtual DbSet<EmployeeCertification> EmployeeCertifications { get; set; }

    public virtual DbSet<EmployeeCompetency> EmployeeCompetencies { get; set; }

    public virtual DbSet<EmployeeHealthItem> EmployeeHealthItems { get; set; }
  }
}
