using System.Collections.Generic;
using System.Linq;

namespace DigitalLibrary.DAL
{
	public class AuthorRepository : IAuthorRepository
	{
		private readonly ApplicationDbContext _context;

		public AuthorRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Author> GetAll()
		{
			return _context.Authors;
		}
	}
}
