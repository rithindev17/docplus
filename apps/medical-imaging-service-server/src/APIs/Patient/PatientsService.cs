using MedicalImagingService.Infrastructure;

namespace MedicalImagingService.APIs;

public class PatientsService : PatientsServiceBase
{
    public PatientsService(MedicalImagingServiceDbContext context)
        : base(context) { }
}
