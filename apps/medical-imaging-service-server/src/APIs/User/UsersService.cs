using MedicalImagingService.Infrastructure;

namespace MedicalImagingService.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(MedicalImagingServiceDbContext context)
        : base(context) { }
}
