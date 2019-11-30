using System.Collections.Generic;
using System.Linq;

namespace DigitalLibrary.DAL
{
	public class BookRepository : IBookRepository
	{
		private readonly ApplicationDbContext _context;

		public BookRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Book> GetAll()
		{
			return _context.Books;
		}
	}
}
