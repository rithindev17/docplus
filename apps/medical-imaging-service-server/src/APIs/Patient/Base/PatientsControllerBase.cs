using MedicalImagingService.APIs;
using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PatientsControllerBase : ControllerBase
{
    protected readonly IPatientsService _service;

    public PatientsControllerBase(IPatientsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Patient
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Patient>> CreatePatient(PatientCreateInput input)
    {
        var patient = await _service.CreatePatient(input);

        return CreatedAtAction(nameof(Patient), new { id = patient.Id }, patient);
    }

    /// <summary>
    /// Delete one Patient
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePatient([FromRoute()] PatientWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePatient(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Patients
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Patient>>> Patients(
        [FromQuery()] PatientFindManyArgs filter
    )
    {
        return Ok(await _service.Patients(filter));
    }

    /// <summary>
    /// Meta data about Patient records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PatientsMeta(
        [FromQuery()] PatientFindManyArgs filter
    )
    {
        return Ok(await _service.PatientsMeta(filter));
    }

    /// <summary>
    /// Get one Patient
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Patient>> Patient([FromRoute()] PatientWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Patient(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Patient
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePatient(
        [FromRoute()] PatientWhereUniqueInput uniqueId,
        [FromQuery()] PatientUpdateInput patientUpdateDto
    )
    {
        try
        {
            await _service.UpdatePatient(uniqueId, patientUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
