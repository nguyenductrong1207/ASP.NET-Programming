using LibraryManagement.Models;

namespace LibraryManagement.Services
{
	public interface IRoleService
	{
		Task<List<string>> GetAllRolesAsync();
		Task<bool> IsUserInRoleAsync(string userId, string role);
	}
}
