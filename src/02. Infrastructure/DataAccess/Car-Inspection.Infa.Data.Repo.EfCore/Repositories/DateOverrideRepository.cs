using Car_Inspection.Domain.Core.DateOverride.Data;
using Car_Inspection.Domain.Core.DateOverride.DTOs;
using Car_Inspection.Domain.Core.DateOverride.Entities;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

namespace Car_Inspection.Infa.Data.Repo.EfCore.Repositories;

public class DateOverrideRepository(AppDbContext context) : IDateOverrideRepository
{
    public bool Create(CreateDateOverrideDto createDateOverride)
    {
        var dateOverride = new DateOverride()
        {
            SpecificDate = createDateOverride.SpecificDate,
            NewCapacity = createDateOverride.NewCapacity,
            IsClosed = createDateOverride.IsClosed,
            Reason = createDateOverride.Reason,
            CompanyId = createDateOverride.CompanyId
        };
        context.Add(dateOverride);
        return context.SaveChanges() > 0;
    }

    public List<DateOverrideDto> GetAll()
    {
        return context.DateOverrides.Select(d => new DateOverrideDto()
        {
            Id = d.Id,
            SpecificDate = d.SpecificDate,
            NewCapacity = d.NewCapacity,
            IsClosed = d.IsClosed,
            Reason = d.Reason,
            CompanyId = d.CompanyId
        }).ToList();
    }

    public bool IsDateBlocked(DateOnly date)
    {
        return context.DateOverrides.Any(d => d.SpecificDate == date && d.IsClosed);
    }

    public int? GetMaxCapacityForDate(DateOnly date)
    {
        var dateOverride = context.DateOverrides
            .FirstOrDefault(d => d.SpecificDate == date);
        return dateOverride?.NewCapacity;
    }
}