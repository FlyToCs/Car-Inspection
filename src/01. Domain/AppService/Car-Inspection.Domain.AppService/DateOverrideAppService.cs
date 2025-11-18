using Car_Inspection.Domain.Core._common;
using Car_Inspection.Domain.Core.DateOverride.AppServices;
using Car_Inspection.Domain.Core.DateOverride.DTOs;
using Car_Inspection.Domain.Core.DateOverride.Services;

namespace Car_Inspection.Domain.AppService;

public class DateOverrideAppService(IDateOverrideService dateOverrideService) : IDateOverrideAppService
{
    public Result<bool> Create(CreateDateOverrideDto createDateOverride)
    {
        var result = dateOverrideService.Create(createDateOverride);
        if (result!)
        {
            return Result<bool>.Failure("ایحاد محدودیت زمانی خاص با خطا مواجه شد");

        }
        return Result<bool>.Success("عملیات با موقیت انحام شد", result);

    }

    public List<DateOverrideDto> GetAll()
    {
        return dateOverrideService.GetAll();
    }
}