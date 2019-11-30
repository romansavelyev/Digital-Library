using System.Collections.Generic;

namespace DigitalLibrary.DAL
{
    public interface IApplicationUserRepository
    {
	    IEnumerable<ApplicationUser> GetAll();
	    ApplicationUser GetByEmail(string email);
    }
}
