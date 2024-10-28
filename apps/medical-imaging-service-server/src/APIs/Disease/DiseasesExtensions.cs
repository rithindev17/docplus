using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.Infrastructure.Models;

namespace MedicalImagingService.APIs.Extensions;

public static class DiseasesExtensions
{
    public static Disease ToDto(this DiseaseDbModel model)
    {
        return new Disease
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static DiseaseDbModel ToModel(
        this DiseaseUpdateInput updateDto,
        DiseaseWhereUniqueInput uniqueId
    )
    {
        var disease = new DiseaseDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            disease.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            disease.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return disease;
    }
}
