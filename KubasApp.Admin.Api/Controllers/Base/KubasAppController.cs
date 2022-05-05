using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubasApp.Admin.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class KubasAppController : ControllerBase 
{
    
}