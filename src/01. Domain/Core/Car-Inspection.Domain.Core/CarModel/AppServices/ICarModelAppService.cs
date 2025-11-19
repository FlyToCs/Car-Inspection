using Car_Inspection.Domain.Core.CarModel.DTOs;

namespace Car_Inspection.Domain.Core.CarModel.AppServices;

public interface ICarModelAppService
{
    List<CarModelDto> GetAllByCompany(int companyId);
    List<CarModelDto> GetAll();
}