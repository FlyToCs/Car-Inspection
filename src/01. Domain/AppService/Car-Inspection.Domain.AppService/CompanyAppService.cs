using Car_Inspection.Domain.Core.Company.AppServices;
using Car_Inspection.Domain.Core.Company.DTOs;
using Car_Inspection.Domain.Core.Company.Services;

namespace Car_Inspection.Domain.AppService;

public class CompanyAppService(ICompanyService companyService) : ICompanyAppService
{
    public List<CompanyDto> GetAll()
    {
        return companyService.GetAll();
    }
}