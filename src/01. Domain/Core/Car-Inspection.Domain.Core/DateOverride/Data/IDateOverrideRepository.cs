using Car_Inspection.Domain.Core.DateOverride.DTOs;

namespace Car_Inspection.Domain.Core.DateOverride.Data;

public interface IDateOverrideRepository
{
    bool Create(CreateDateOverrideDto createDateOverride);
    List<DateOverrideDto> GetAll();
}