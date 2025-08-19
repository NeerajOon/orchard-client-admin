using Sohan.User.Indexes;
using Sohan.User.Models;
using Sohan.User.ViewModels;

namespace Sohan.User.Helpers;

/// <summary>
/// Provides helper methods for vendor user operations.
/// </summary>
public interface ICustomerHelper
{
	/// <summary>
	/// Adds a new vendor user using the provided registration data and user ID.
	/// </summary>
	/// <param name="model">The registration view model.</param>
	/// <param name="userId">The ID of the user.</param>
	Task<Customer> AddUserAsync(UserViewModel model);

    /// <summary>
    /// Get User Details by Id.
    /// </summary>
    /// <param name="userId">userId.</param>
    /// <returns>If user found with the userId then It will return model otherwise null.</returns>
    Task<CustomerIndex> UserLoginAsync(UserLoginModel modal);

}
