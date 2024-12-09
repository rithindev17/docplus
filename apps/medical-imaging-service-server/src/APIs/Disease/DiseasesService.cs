using MedicalImagingService.Infrastructure;

namespace MedicalImagingService.APIs;

public class DiseasesService : DiseasesServiceBase
{
    public DiseasesService(MedicalImagingServiceDbContext context)
        : base(context) { }
}
