using Car_Inspection.Domain.Core.Company.DTOs;

namespace Car_Inspection.Domain.Core.Company.Data;

public interface ICompanyRepository
{
    List<CompanyDto> GetAll();
}