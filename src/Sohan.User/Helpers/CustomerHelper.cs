using Microsoft.AspNetCore.Identity;
using OrchardCore.Users.Models;
using Sohan.User.Indexes;
using Sohan.User.Models;
using Sohan.User.ViewModels;
using YesSql;

namespace Sohan.User.Helpers;

public class CustomerHelper(ISession session) : ICustomerHelper
{
	private readonly ISession _session = session;

	public async Task<Customer> AddUserAsync(UserViewModel model)
	{
		var customer = new Customer
		{
			Name = model.Name,
			Email = model.Email,
			Username = model.Username,
			Password = model.Password,
		};

		await _session.SaveAsync(customer);
		return customer;
	}

	public async Task<UserViewModel> UserLoginAsync(UserLoginModel modal)
	{
		if (modal?.Name == null || modal.Password == null)
			return null;

		var customer = await _session.QueryIndex<CustomerIndex>()
	   .Where(x => (x.Username == modal.Name || x.Email == modal.Name))
	   .FirstOrDefaultAsync();

		if (customer == null)
			return null;
		var user = new UserViewModel
		{
			Name = customer.Name,
			Username = customer.Username,
			Email = customer.Email,
		};

		// Verify password
		//var result = _passwordHasher.VerifyHashedPassword(customer, customer.Password, modal.Password);

		return user;
	}
}
