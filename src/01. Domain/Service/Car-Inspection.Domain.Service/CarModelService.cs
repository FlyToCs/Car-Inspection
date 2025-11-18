using Car_Inspection.Domain.Core.CarModel.Data;
using Car_Inspection.Domain.Core.CarModel.DTOs;
using Car_Inspection.Domain.Core.CarModel.Services;

namespace Car_Inspection.Domain.Service;

public class CarModelService(ICarModelRepository carModelRepo): ICarModelService
{
    public List<CarModelDto> GetAllByCompany(int companyId)
    {
        return carModelRepo.GetAllByCompany(companyId);
    }
}