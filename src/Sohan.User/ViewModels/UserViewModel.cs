using System.ComponentModel.DataAnnotations;

namespace Sohan.User.ViewModels;

public class UserViewModel
{
	public string? Name { get; set; }
	public string? Email { get; set; }
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? ConfirmPassword { get; set; }
}


