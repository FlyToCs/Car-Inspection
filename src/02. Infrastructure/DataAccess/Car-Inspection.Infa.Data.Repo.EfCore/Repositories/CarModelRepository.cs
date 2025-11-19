using Car_Inspection.Domain.Core.CarModel.Data;
using Car_Inspection.Domain.Core.CarModel.DTOs;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

namespace Car_Inspection.Infa.Data.Repo.EfCore.Repositories;

public class CarModelRepository(AppDbContext context) : ICarModelRepository
{
    public List<CarModelDto> GetAllByCompany(int companyId)
    {
        return context.CarModels.Where(c => c.CompanyId == companyId)
            .Select(c => new CarModelDto()
        {
            Id = c.Id,
            Name = c.Name,
            CompanyId = c.CompanyId,
            
            }).ToList();
    }

    public List<CarModelDto> GetAll()
    {
        return context.CarModels
            .Select(c => new CarModelDto()
            {
                Id = c.Id,
                Name = c.Name,
                CompanyId = c.CompanyId
            }).ToList();
    }

    public int GetCompanyIdByCarModelId(int carModelId)
    {
        return context.CarModels
            .Where(c => c.Id == carModelId)
            .Select(c => c.CompanyId)
            .FirstOrDefault();
    }

    public bool IsCompanyAllowedOnDay(int companyId, DayOfWeek appointmentDayOfWeek)
    {
        return context.Set<Domain.Core.ScheduleRule.Entities.ScheduleRule>()
            .Any(sr => sr.DayOfWeek == appointmentDayOfWeek && sr.CompanyId == companyId);
    }
}