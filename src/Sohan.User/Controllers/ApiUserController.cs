using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sohan.User.Helpers;
using Sohan.User.ViewModels;
using System.Security.Claims;

namespace Sohan.User.Controllers;

[Route("api/User")]
[ApiController]
public class ApiUserController(ICustomerHelper customer) : Controller
{
	private readonly ICustomerHelper _customer = customer;

	[HttpPost("register")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Register([FromBody] UserViewModel model)
	{
		var user = await _customer.AddUserAsync(model);
		return Ok(new { message = "Received user", user });
	}

	[HttpPost("login")]
	//[IgnoreAntiforgeryToken] // Disable for API login
	public async Task<IActionResult> Login([FromBody] UserLoginModel modal)
	{
		var user = await _customer.UserLoginAsync(modal);

		if (user == null)
		{
			return Unauthorized(new { message = "Invalid username or password." });
		}
		return Ok(new { message = "Login successful.", user });
	}
	
	[HttpGet("profile")]
	public IActionResult Profile()
	{
		var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		var username = User.Identity?.Name;
		var email = User.FindFirstValue(ClaimTypes.Email);
		Console.WriteLine("username-=-=-=-=" + username);
		return Ok(new
		{
			Message = $"Hello {username}!",
			User = new
			{
				Id = userId,
				Username = username,
				Email = email
			}
		});
	}
}