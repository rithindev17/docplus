using MedicalImagingService.Infrastructure;

namespace MedicalImagingService.APIs;

public class ScansService : ScansServiceBase
{
    public ScansService(MedicalImagingServiceDbContext context)
        : base(context) { }
}
