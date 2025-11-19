using Car_Inspection.Domain.Core.DateOverride.Data;
using Car_Inspection.Domain.Core.DateOverride.DTOs;
using Car_Inspection.Domain.Core.DateOverride.Services;

namespace Car_Inspection.Domain.Service;

public class DateOverrideService(IDateOverrideRepository dateOverrideRepo) : IDateOverrideService
{
    public bool Create(CreateDateOverrideDto createDateOverride)
    {
        return dateOverrideRepo.Create(createDateOverride);
    }

    public List<DateOverrideDto> GetAll()
    {
        return dateOverrideRepo.GetAll();
    }

    public bool IsDateBlocked(DateOnly date)
    {
        return dateOverrideRepo.IsDateBlocked(date);
    }

    public int? GetMaxCapacityForDate(DateOnly date)
    {
        return dateOverrideRepo.GetMaxCapacityForDate(date);
    }
}