using MedicalImagingService.APIs;
using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.APIs.Errors;
using MedicalImagingService.APIs.Extensions;
using MedicalImagingService.Infrastructure;
using MedicalImagingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalImagingService.APIs;

public abstract class ScansServiceBase : IScansService
{
    protected readonly MedicalImagingServiceDbContext _context;

    public ScansServiceBase(MedicalImagingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Scan
    /// </summary>
    public async Task<Scan> CreateScan(ScanCreateInput createDto)
    {
        var scan = new ScanDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            scan.Id = createDto.Id;
        }

        _context.Scans.Add(scan);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ScanDbModel>(scan.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Scan
    /// </summary>
    public async Task DeleteScan(ScanWhereUniqueInput uniqueId)
    {
        var scan = await _context.Scans.FindAsync(uniqueId.Id);
        if (scan == null)
        {
            throw new NotFoundException();
        }

        _context.Scans.Remove(scan);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Scans
    /// </summary>
    public async Task<List<Scan>> Scans(ScanFindManyArgs findManyArgs)
    {
        var scans = await _context
            .Scans.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return scans.ConvertAll(scan => scan.ToDto());
    }

    /// <summary>
    /// Meta data about Scan records
    /// </summary>
    public async Task<MetadataDto> ScansMeta(ScanFindManyArgs findManyArgs)
    {
        var count = await _context.Scans.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Scan
    /// </summary>
    public async Task<Scan> Scan(ScanWhereUniqueInput uniqueId)
    {
        var scans = await this.Scans(
            new ScanFindManyArgs { Where = new ScanWhereInput { Id = uniqueId.Id } }
        );
        var scan = scans.FirstOrDefault();
        if (scan == null)
        {
            throw new NotFoundException();
        }

        return scan;
    }

    /// <summary>
    /// Update one Scan
    /// </summary>
    public async Task UpdateScan(ScanWhereUniqueInput uniqueId, ScanUpdateInput updateDto)
    {
        var scan = updateDto.ToModel(uniqueId);

        _context.Entry(scan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Scans.Any(e => e.Id == scan.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
