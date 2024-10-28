using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;

namespace MedicalImagingService.APIs;

public interface IDiseasesService
{
    /// <summary>
    /// Create one Disease
    /// </summary>
    public Task<Disease> CreateDisease(DiseaseCreateInput disease);

    /// <summary>
    /// Delete one Disease
    /// </summary>
    public Task DeleteDisease(DiseaseWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Diseases
    /// </summary>
    public Task<List<Disease>> Diseases(DiseaseFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Disease records
    /// </summary>
    public Task<MetadataDto> DiseasesMeta(DiseaseFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Disease
    /// </summary>
    public Task<Disease> Disease(DiseaseWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Disease
    /// </summary>
    public Task UpdateDisease(DiseaseWhereUniqueInput uniqueId, DiseaseUpdateInput updateDto);
}
