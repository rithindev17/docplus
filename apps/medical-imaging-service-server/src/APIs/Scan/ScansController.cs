using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[ApiController()]
public class ScansController : ScansControllerBase
{
    public ScansController(IScansService service)
        : base(service) { }
}
