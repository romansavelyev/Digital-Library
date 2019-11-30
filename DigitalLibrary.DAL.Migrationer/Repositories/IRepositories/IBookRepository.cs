using System.Collections.Generic;

namespace DigitalLibrary.DAL
{
    public interface IBookRepository
    {
	    IEnumerable<Book> GetAll();
    }
}
