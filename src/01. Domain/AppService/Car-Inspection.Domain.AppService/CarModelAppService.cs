using Car_Inspection.Domain.Core.CarModel.AppServices;
using Car_Inspection.Domain.Core.CarModel.Data;
using Car_Inspection.Domain.Core.CarModel.DTOs;
using Car_Inspection.Domain.Core.CarModel.Services;

namespace Car_Inspection.Domain.AppService;

public class CarModelAppService(ICarModelService carModelService) : ICarModelAppService
{
    public List<CarModelDto> GetAllByCompany(int companyId)
    {
        return carModelService.GetAllByCompany(companyId);
    }
}