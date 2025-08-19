using Microsoft.AspNetCore.Mvc;
using Sohan.User.Helpers;
using Sohan.User.ViewModels;

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
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Login([FromBody] UserLoginModel modal)
	{
		var user = _customer.UserLoginAsync(modal);

		if ( user == null)
		{
			return Unauthorized(new { message = "Invalid username or password." });
		}
		return Ok(new { message = "Login successful.", user });
	}
}