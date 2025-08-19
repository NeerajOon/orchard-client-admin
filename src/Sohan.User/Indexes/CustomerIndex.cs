
using Sohan.User.Models;
using YesSql.Indexes;

namespace Sohan.User.Indexes;

public class CustomerIndex : MapIndex
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
}

public class CustomerIndexProvider : IndexProvider<Customer>
{
	public override void Describe(DescribeContext<Customer> context) => context.For<CustomerIndex>().Map(user => new CustomerIndex
	{
		Name = user.Name,
		Email = user.Email,
		Username = user.Username,
		Password = user.Password,
	});
}
