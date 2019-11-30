using System.Collections.Generic;

namespace DigitalLibrary.DAL
{
    public interface IAuthorRepository
    {
	    IEnumerable<Author> GetAll();
    }
}
