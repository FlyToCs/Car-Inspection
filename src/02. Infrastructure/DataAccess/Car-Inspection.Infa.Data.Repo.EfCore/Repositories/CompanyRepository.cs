using Car_Inspection.Domain.Core.Company.Data;
using Car_Inspection.Domain.Core.Company.DTOs;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

namespace Car_Inspection.Infa.Data.Repo.EfCore.Repositories;

public class CompanyRepository(AppDbContext context) : ICompanyRepository
{
    public List<CompanyDto> GetAll()
    {
        return context.Companies
            .Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
    }
}