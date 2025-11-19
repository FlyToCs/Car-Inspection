using Car_Inspection.Domain.AppService;
using Car_Inspection.Domain.Core.Appointment.AppServices;
using Car_Inspection.Domain.Core.Appointment.Data;
using Car_Inspection.Domain.Core.Appointment.Services;
using Car_Inspection.Domain.Core.CarModel.AppServices;
using Car_Inspection.Domain.Core.CarModel.Data;
using Car_Inspection.Domain.Core.CarModel.Services;
using Car_Inspection.Domain.Core.Company.AppServices;
using Car_Inspection.Domain.Core.Company.Data;
using Car_Inspection.Domain.Core.Company.Services;
using Car_Inspection.Domain.Core.DateOverride.AppServices;
using Car_Inspection.Domain.Core.DateOverride.Data;
using Car_Inspection.Domain.Core.DateOverride.Services;
using Car_Inspection.Domain.Core.RejectedAppointment.AppServices;
using Car_Inspection.Domain.Core.RejectedAppointment.Data;
using Car_Inspection.Domain.Core.RejectedAppointment.Services;
using Car_Inspection.Domain.Core.ScheduleRule.AppServices;
using Car_Inspection.Domain.Core.ScheduleRule.Data;
using Car_Inspection.Domain.Core.ScheduleRule.Services;
using Car_Inspection.Domain.Core.User.AppServices;
using Car_Inspection.Domain.Core.User.Data;
using Car_Inspection.Domain.Core.User.Services;
using Car_Inspection.Domain.Service;
using Car_Inspection.Infa.Data.Repo.EfCore.Repositories;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IRejectedAppointmentService, RejectedAppointmentService>();
builder.Services.AddScoped<IDateOverrideService, DateOverrideService>();
builder.Services.AddScoped<IScheduleRuleService, ScheduleRuleService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICarModelService, CarModelService>();


builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IAppointmentAppService, AppointmentAppService>();
builder.Services.AddScoped<IRejectedAppointmentAppService, RejectedAppointmentAppService>();
builder.Services.AddScoped<IDateOverrideAppService, DateOverrideAppService>();
builder.Services.AddScoped<IScheduleRuleAppService, ScheduleRuleAppService>();
builder.Services.AddScoped<ICompanyAppService, CompanyAppService>();
builder.Services.AddScoped<ICarModelAppService, CarModelAppService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IRejectedAppointmentRepository, RejectedAppointmentRepository>();
builder.Services.AddScoped<IDateOverrideRepository, DateOverrideRepository>();
builder.Services.AddScoped<IScheduleRuleRepository, ScheduleRuleRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();



var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
