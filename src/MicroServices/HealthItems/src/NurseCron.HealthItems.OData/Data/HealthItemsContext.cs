using NurseCron.HealthItems.Models;
using Microsoft.EntityFrameworkCore;

namespace NurseCron.HealthItems.OData.Data
{
  public partial class HealthItemsContext : DbContext, IHealthItemsContext
  {
    public HealthItemsContext(DbContextOptions<HealthItemsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HealthItem> HealthItems { get; set; }
  }
}
