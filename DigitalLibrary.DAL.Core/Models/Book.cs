using System.Collections.Generic;

namespace DigitalLibrary.DAL
{
    public class Book
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

	    public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
	}
}
