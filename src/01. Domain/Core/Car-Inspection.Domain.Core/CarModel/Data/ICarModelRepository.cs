using Car_Inspection.Domain.Core.CarModel.DTOs;

namespace Car_Inspection.Domain.Core.CarModel.Data;

public interface ICarModelRepository
{
    List<CarModelDto> GetAllByCompany(int companyId);
    List<CarModelDto> GetAll();
    int GetCompanyIdByCarModelId(int carModelId);
    bool IsCompanyAllowedOnDay(int companyId, DayOfWeek appointmentDayOfWeek);
}