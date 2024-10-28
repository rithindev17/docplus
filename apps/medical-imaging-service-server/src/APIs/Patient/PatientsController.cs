using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[ApiController()]
public class PatientsController : PatientsControllerBase
{
    public PatientsController(IPatientsService service)
        : base(service) { }
}
