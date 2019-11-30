using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalLibrary.DAL
{
    public class AuthorBook
    {
		[Key, Column(Order = 0)]
		public int AuthorId { get; set; }
		[Key, Column(Order = 10)]
		public int BookId { get; set; }

		public virtual Author Author { get; set; }
		public virtual Book Book { get; set; }
	}
}
