using Mapster;
using MarketApi.Model.Request.Account;
using MarketPalceManagement.Account.Abstractions;
using MarketPalceManagement.Account.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MarketApi.Controllers;
[Route("[controller]")]
[ApiController]

public class AccountController : ControllerBase
{
    private readonly IUserAuthentication _userAuthentication;

    public AccountController(IUserAuthentication userAuthentication)
    {
        _userAuthentication = userAuthentication;
    }

    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest is null)
            return BadRequest();

        var token = await _userAuthentication.AuthenticateAsync(loginRequest.Adapt<LoginServiceModel>());

        if (token is null)
            return Unauthorized();

        return Ok(JsonSerializer.Serialize(token));
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest is null)
            return BadRequest();

        var result = await _userAuthentication.RegisterAsync(registerRequest.Adapt<RegisterServiceModel>());

        return Ok(result);
    }
}
