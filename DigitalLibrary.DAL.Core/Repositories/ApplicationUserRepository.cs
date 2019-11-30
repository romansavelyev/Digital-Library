using System.Collections.Generic;
using System.Linq;

namespace DigitalLibrary.DAL
{
	public class ApplicationUserRepository : IApplicationUserRepository
	{
		private readonly ApplicationDbContext _context;

		public ApplicationUserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<ApplicationUser> GetAll()
		{
			return _context.Users;
		}

		public ApplicationUser GetByEmail(string email)
		{
			return _context.Users.FirstOrDefault(x => x.Email == email);
		}

	}
}
