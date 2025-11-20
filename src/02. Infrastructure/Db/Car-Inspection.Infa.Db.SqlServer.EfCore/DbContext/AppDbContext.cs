using Car_Inspection.Domain.Core.Appointment.Entities;
using Car_Inspection.Domain.Core.CarModel.Entities;
using Car_Inspection.Domain.Core.Company.Entities;
using Car_Inspection.Domain.Core.DateOverride.Entities;
using Car_Inspection.Domain.Core.RejectedAppointment.Entities;
using Car_Inspection.Domain.Core.ScheduleRule.Entities;
using Car_Inspection.Domain.Core.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

public class AppDbContext(DbContextOptions<AppDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<RejectedAppointment> RejectedAppointments { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<DateOverride> DateOverrides { get; set; }
    public DbSet<ScheduleRule> ScheduleRules { get; set; }
    public DbSet<CarImg> CarImgs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}