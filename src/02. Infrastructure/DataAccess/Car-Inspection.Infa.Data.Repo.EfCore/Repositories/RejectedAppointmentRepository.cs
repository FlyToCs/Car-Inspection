using Car_Inspection.Domain.Core.RejectedAppointment.Data;
using Car_Inspection.Domain.Core.RejectedAppointment.DTOs;
using Car_Inspection.Domain.Core.RejectedAppointment.Entities;
using Car_Inspection.Infa.Db.SqlServer.EfCore.DbContext;

namespace Car_Inspection.Infa.Data.Repo.EfCore.Repositories;

public class RejectedAppointmentRepository(AppDbContext context) : IRejectedAppointmentRepository
{
    public bool Create(CreateRejectedAppointmentDto createRejectedAppointment)
    {
        var rejectedAppointment = new RejectedAppointment()
        {
            LicensePlate = createRejectedAppointment.LicensePlate,
            ProductionYear = createRejectedAppointment.ProductionYear,
            OwnerNationalId = createRejectedAppointment.OwnerNationalId,
            OwnerMobile = createRejectedAppointment.OwnerMobile,
            CarModelId = createRejectedAppointment.CarModelId
        };
        context.Add(rejectedAppointment);
        return context.SaveChanges() > 0;
    }

    public List<RejectedAppointmentDto> GetAll()
    {
        return context.Set<RejectedAppointment>()
            .Select(ra => new RejectedAppointmentDto()
            {
                Id = ra.Id,
                CreatedAt = ra.CreatedAt,
                LicensePlate = ra.LicensePlate,
                ProductionYear = ra.ProductionYear,
                OwnerMobile = ra.OwnerMobile,
                OwnerNationalId = ra.OwnerNationalId,
                Reason = ra.Reason,
                CarModelId = ra.CarModelId
            })
            .ToList();
    }
}