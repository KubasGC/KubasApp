using KubasApp.Admin.Api.Controllers.Base;
using KubasApp.Admin.Api.DTOs.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubasApp.Admin.Api.Controllers;

public class AccountController : KubasAppController
{
    [HttpPost("login")]
    [AllowAnonymous]
    public Task<IActionResult> Login(LoginRequestDto request)
    {
        return Task.FromResult<IActionResult>(Ok());
    }
}