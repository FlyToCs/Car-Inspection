using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.DateOverride.DTOs;

namespace Car_Inspection.Domain.Core.DateOverride.AppServices;

public interface IDateOverrideAppService
{
    Result<bool> Create(CreateDateOverrideDto createDateOverride);
    List<DateOverrideDto> GetAll();

}