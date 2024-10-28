using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;

namespace MedicalImagingService.APIs;

public interface IScansService
{
    /// <summary>
    /// Create one Scan
    /// </summary>
    public Task<Scan> CreateScan(ScanCreateInput scan);

    /// <summary>
    /// Delete one Scan
    /// </summary>
    public Task DeleteScan(ScanWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Scans
    /// </summary>
    public Task<List<Scan>> Scans(ScanFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Scan records
    /// </summary>
    public Task<MetadataDto> ScansMeta(ScanFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Scan
    /// </summary>
    public Task<Scan> Scan(ScanWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Scan
    /// </summary>
    public Task UpdateScan(ScanWhereUniqueInput uniqueId, ScanUpdateInput updateDto);
}
