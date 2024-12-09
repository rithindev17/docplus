using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[ApiController()]
public class DiseasesController : DiseasesControllerBase
{
    public DiseasesController(IDiseasesService service)
        : base(service) { }
}
