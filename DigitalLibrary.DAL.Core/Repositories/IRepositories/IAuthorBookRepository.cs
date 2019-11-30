using System.Collections.Generic;

namespace DigitalLibrary.DAL
{
    public interface IAuthorBookRepository
    {
	    IEnumerable<AuthorBook> GetAll();
    }
}
