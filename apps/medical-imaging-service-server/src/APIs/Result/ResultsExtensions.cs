using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.Infrastructure.Models;

namespace MedicalImagingService.APIs.Extensions;

public static class ResultsExtensions
{
    public static Result ToDto(this ResultDbModel model)
    {
        return new Result
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ResultDbModel ToModel(
        this ResultUpdateInput updateDto,
        ResultWhereUniqueInput uniqueId
    )
    {
        var result = new ResultDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            result.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            result.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return result;
    }
}
