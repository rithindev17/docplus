using MedicalImagingService.APIs;
using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DiseasesControllerBase : ControllerBase
{
    protected readonly IDiseasesService _service;

    public DiseasesControllerBase(IDiseasesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Disease
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Disease>> CreateDisease(DiseaseCreateInput input)
    {
        var disease = await _service.CreateDisease(input);

        return CreatedAtAction(nameof(Disease), new { id = disease.Id }, disease);
    }

    /// <summary>
    /// Delete one Disease
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDisease([FromRoute()] DiseaseWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteDisease(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Diseases
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Disease>>> Diseases(
        [FromQuery()] DiseaseFindManyArgs filter
    )
    {
        return Ok(await _service.Diseases(filter));
    }

    /// <summary>
    /// Meta data about Disease records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DiseasesMeta(
        [FromQuery()] DiseaseFindManyArgs filter
    )
    {
        return Ok(await _service.DiseasesMeta(filter));
    }

    /// <summary>
    /// Get one Disease
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Disease>> Disease([FromRoute()] DiseaseWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Disease(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Disease
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDisease(
        [FromRoute()] DiseaseWhereUniqueInput uniqueId,
        [FromQuery()] DiseaseUpdateInput diseaseUpdateDto
    )
    {
        try
        {
            await _service.UpdateDisease(uniqueId, diseaseUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
