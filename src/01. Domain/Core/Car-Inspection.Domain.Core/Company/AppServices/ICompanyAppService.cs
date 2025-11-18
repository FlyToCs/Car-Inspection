using Car_Inspection.Domain.Core.Company.DTOs;

namespace Car_Inspection.Domain.Core.Company.AppServices;

public interface ICompanyAppService
{
    List<CompanyDto> GetAll();
}