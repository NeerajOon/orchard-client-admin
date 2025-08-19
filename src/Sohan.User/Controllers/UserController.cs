using Microsoft.AspNetCore.Mvc;

using Sohan.User.ViewModels;
namespace Sohan.User.Controllers;

public class UserController : Controller
{

	public UserController()
	{
	}

	[HttpGet("userlogin")]
	public IActionResult Login()
	{
		var model = new UserLoginModel { };
		return View(model);
	}

	[HttpGet("Register")]
	public IActionResult Registration()
	{
		var model = new UserViewModel
		{
		};
		return View(model);
	}

	[HttpGet("Profile")]
	public IActionResult Profile()
	{
		var model = new UserViewModel
		{
		};
		return View(model);
	}

}
