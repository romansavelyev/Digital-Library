using System.Collections.Generic;

namespace DigitalLibrary.DAL
{
    public class Author
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image  { get; set; }
		public string Description { get; set; }

	    public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
	}
}
