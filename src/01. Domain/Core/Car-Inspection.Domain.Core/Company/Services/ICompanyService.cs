using Car_Inspection.Domain.Core.Company.DTOs;

namespace Car_Inspection.Domain.Core.Company.Services;

public interface ICompanyService
{
    List<CompanyDto> GetAll();
}