using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[ApiController()]
public class ResultsController : ResultsControllerBase
{
    public ResultsController(IResultsService service)
        : base(service) { }
}
