using MedicalImagingService.Infrastructure;

namespace MedicalImagingService.APIs;

public class ResultsService : ResultsServiceBase
{
    public ResultsService(MedicalImagingServiceDbContext context)
        : base(context) { }
}
