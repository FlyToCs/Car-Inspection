using Car_Inspection.Domain.Core.Company.Data;
using Car_Inspection.Domain.Core.Company.DTOs;
using Car_Inspection.Domain.Core.Company.Services;

namespace Car_Inspection.Domain.Service;

public class CompanyService(ICompanyRepository companyRepo) : ICompanyService
{
    public List<CompanyDto> GetAll()
    {
        return companyRepo.GetAll();
    }
}