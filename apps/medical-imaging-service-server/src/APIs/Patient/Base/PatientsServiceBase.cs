using MedicalImagingService.APIs;
using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.APIs.Errors;
using MedicalImagingService.APIs.Extensions;
using MedicalImagingService.Infrastructure;
using MedicalImagingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalImagingService.APIs;

public abstract class PatientsServiceBase : IPatientsService
{
    protected readonly MedicalImagingServiceDbContext _context;

    public PatientsServiceBase(MedicalImagingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Patient
    /// </summary>
    public async Task<Patient> CreatePatient(PatientCreateInput createDto)
    {
        var patient = new PatientDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            patient.Id = createDto.Id;
        }

        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PatientDbModel>(patient.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Patient
    /// </summary>
    public async Task DeletePatient(PatientWhereUniqueInput uniqueId)
    {
        var patient = await _context.Patients.FindAsync(uniqueId.Id);
        if (patient == null)
        {
            throw new NotFoundException();
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Patients
    /// </summary>
    public async Task<List<Patient>> Patients(PatientFindManyArgs findManyArgs)
    {
        var patients = await _context
            .Patients.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return patients.ConvertAll(patient => patient.ToDto());
    }

    /// <summary>
    /// Meta data about Patient records
    /// </summary>
    public async Task<MetadataDto> PatientsMeta(PatientFindManyArgs findManyArgs)
    {
        var count = await _context.Patients.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Patient
    /// </summary>
    public async Task<Patient> Patient(PatientWhereUniqueInput uniqueId)
    {
        var patients = await this.Patients(
            new PatientFindManyArgs { Where = new PatientWhereInput { Id = uniqueId.Id } }
        );
        var patient = patients.FirstOrDefault();
        if (patient == null)
        {
            throw new NotFoundException();
        }

        return patient;
    }

    /// <summary>
    /// Update one Patient
    /// </summary>
    public async Task UpdatePatient(PatientWhereUniqueInput uniqueId, PatientUpdateInput updateDto)
    {
        var patient = updateDto.ToModel(uniqueId);

        _context.Entry(patient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Patients.Any(e => e.Id == patient.Id))
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
