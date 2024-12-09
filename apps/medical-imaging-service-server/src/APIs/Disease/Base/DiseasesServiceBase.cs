using MedicalImagingService.APIs;
using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.APIs.Errors;
using MedicalImagingService.APIs.Extensions;
using MedicalImagingService.Infrastructure;
using MedicalImagingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalImagingService.APIs;

public abstract class DiseasesServiceBase : IDiseasesService
{
    protected readonly MedicalImagingServiceDbContext _context;

    public DiseasesServiceBase(MedicalImagingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Disease
    /// </summary>
    public async Task<Disease> CreateDisease(DiseaseCreateInput createDto)
    {
        var disease = new DiseaseDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            disease.Id = createDto.Id;
        }

        _context.Diseases.Add(disease);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DiseaseDbModel>(disease.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Disease
    /// </summary>
    public async Task DeleteDisease(DiseaseWhereUniqueInput uniqueId)
    {
        var disease = await _context.Diseases.FindAsync(uniqueId.Id);
        if (disease == null)
        {
            throw new NotFoundException();
        }

        _context.Diseases.Remove(disease);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Diseases
    /// </summary>
    public async Task<List<Disease>> Diseases(DiseaseFindManyArgs findManyArgs)
    {
        var diseases = await _context
            .Diseases.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return diseases.ConvertAll(disease => disease.ToDto());
    }

    /// <summary>
    /// Meta data about Disease records
    /// </summary>
    public async Task<MetadataDto> DiseasesMeta(DiseaseFindManyArgs findManyArgs)
    {
        var count = await _context.Diseases.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Disease
    /// </summary>
    public async Task<Disease> Disease(DiseaseWhereUniqueInput uniqueId)
    {
        var diseases = await this.Diseases(
            new DiseaseFindManyArgs { Where = new DiseaseWhereInput { Id = uniqueId.Id } }
        );
        var disease = diseases.FirstOrDefault();
        if (disease == null)
        {
            throw new NotFoundException();
        }

        return disease;
    }

    /// <summary>
    /// Update one Disease
    /// </summary>
    public async Task UpdateDisease(DiseaseWhereUniqueInput uniqueId, DiseaseUpdateInput updateDto)
    {
        var disease = updateDto.ToModel(uniqueId);

        _context.Entry(disease).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Diseases.Any(e => e.Id == disease.Id))
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
