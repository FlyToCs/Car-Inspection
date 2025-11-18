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
}