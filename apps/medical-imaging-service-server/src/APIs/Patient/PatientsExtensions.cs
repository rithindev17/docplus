using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.Infrastructure.Models;

namespace MedicalImagingService.APIs.Extensions;

public static class PatientsExtensions
{
    public static Patient ToDto(this PatientDbModel model)
    {
        return new Patient
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PatientDbModel ToModel(
        this PatientUpdateInput updateDto,
        PatientWhereUniqueInput uniqueId
    )
    {
        var patient = new PatientDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            patient.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            patient.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return patient;
    }
}
