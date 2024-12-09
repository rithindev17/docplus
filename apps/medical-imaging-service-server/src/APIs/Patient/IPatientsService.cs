using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;

namespace MedicalImagingService.APIs;

public interface IPatientsService
{
    /// <summary>
    /// Create one Patient
    /// </summary>
    public Task<Patient> CreatePatient(PatientCreateInput patient);

    /// <summary>
    /// Delete one Patient
    /// </summary>
    public Task DeletePatient(PatientWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Patients
    /// </summary>
    public Task<List<Patient>> Patients(PatientFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Patient records
    /// </summary>
    public Task<MetadataDto> PatientsMeta(PatientFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Patient
    /// </summary>
    public Task<Patient> Patient(PatientWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Patient
    /// </summary>
    public Task UpdatePatient(PatientWhereUniqueInput uniqueId, PatientUpdateInput updateDto);
}
