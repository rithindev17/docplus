using MedicalImagingService.APIs;
using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ScansControllerBase : ControllerBase
{
    protected readonly IScansService _service;

    public ScansControllerBase(IScansService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Scan
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Scan>> CreateScan(ScanCreateInput input)
    {
        var scan = await _service.CreateScan(input);

        return CreatedAtAction(nameof(Scan), new { id = scan.Id }, scan);
    }

    /// <summary>
    /// Delete one Scan
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteScan([FromRoute()] ScanWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteScan(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Scans
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Scan>>> Scans([FromQuery()] ScanFindManyArgs filter)
    {
        return Ok(await _service.Scans(filter));
    }

    /// <summary>
    /// Meta data about Scan records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ScansMeta([FromQuery()] ScanFindManyArgs filter)
    {
        return Ok(await _service.ScansMeta(filter));
    }

    /// <summary>
    /// Get one Scan
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Scan>> Scan([FromRoute()] ScanWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Scan(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Scan
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateScan(
        [FromRoute()] ScanWhereUniqueInput uniqueId,
        [FromQuery()] ScanUpdateInput scanUpdateDto
    )
    {
        try
        {
            await _service.UpdateScan(uniqueId, scanUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
