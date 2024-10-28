using Microsoft.AspNetCore.Mvc;

namespace MedicalImagingService.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
