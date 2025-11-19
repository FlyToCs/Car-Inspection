using Car_Inspection.Domain.Core.DateOverride.DTOs;

namespace Car_Inspection.Domain.Core.DateOverride.Services;

public interface IDateOverrideService
{
    bool Create(CreateDateOverrideDto createDateOverride);
    List<DateOverrideDto> GetAll();
    bool IsDateBlocked(DateOnly date);
    int? GetMaxCapacityForDate(DateOnly date);
}