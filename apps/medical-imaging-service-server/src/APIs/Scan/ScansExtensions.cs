using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.Infrastructure.Models;

namespace MedicalImagingService.APIs.Extensions;

public static class ScansExtensions
{
    public static Scan ToDto(this ScanDbModel model)
    {
        return new Scan
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ScanDbModel ToModel(this ScanUpdateInput updateDto, ScanWhereUniqueInput uniqueId)
    {
        var scan = new ScanDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            scan.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            scan.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return scan;
    }
}
