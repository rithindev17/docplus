using MedicalImagingService.APIs;
using MedicalImagingService.APIs.Common;
using MedicalImagingService.APIs.Dtos;
using MedicalImagingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ResultsControllerBase : ControllerBase
{
    protected readonly IResultsService _service;

    public ResultsControllerBase(IResultsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Result
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Result>> CreateResult(ResultCreateInput input)
    {
        var result = await _service.CreateResult(input);

        return CreatedAtAction(nameof(Result), new { id = result.Id }, result);
    }

    /// <summary>
    /// Delete one Result
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteResult([FromRoute()] ResultWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteResult(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Results
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Result>>> Results([FromQuery()] ResultFindManyArgs filter)
    {
        return Ok(await _service.Results(filter));
    }

    /// <summary>
    /// Meta data about Result records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ResultsMeta(
        [FromQuery()] ResultFindManyArgs filter
    )
    {
        return Ok(await _service.ResultsMeta(filter));
    }

    /// <summary>
    /// Get one Result
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Result>> Result([FromRoute()] ResultWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Result(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Result
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateResult(
        [FromRoute()] ResultWhereUniqueInput uniqueId,
        [FromQuery()] ResultUpdateInput resultUpdateDto
    )
    {
        try
        {
            await _service.UpdateResult(uniqueId, resultUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
