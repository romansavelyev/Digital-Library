using System.Collections.Generic;
using System.Linq;

namespace DigitalLibrary.DAL
{
	public class AuthorBookRepository : IAuthorBookRepository
	{
		private readonly ApplicationDbContext _context;

		public AuthorBookRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<AuthorBook> GetAll()
		{
			return _context.AuthorBooks;
		}
	}
}
