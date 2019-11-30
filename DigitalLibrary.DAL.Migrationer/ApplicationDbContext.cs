using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public ApplicationDbContext() { }
	    public ApplicationDbContext(DbContextOptions options) : base(options)
	    {}

	    public DbSet<Author> Authors { get; set; }
	    public DbSet<Book> Books { get; set; }
	    public DbSet<AuthorBook> AuthorBooks { get; set; }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
			modelBuilder.Entity<AuthorBook>()
				.HasKey(a => new { a.AuthorId, a.BookId });

		    base.OnModelCreating(modelBuilder);

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    if (!optionsBuilder.IsConfigured)
		    {
			    //optionsBuilder.UseSqlServer(@"Data Source=MNILAY-ENVY\\SQLEXPRESS;Initial Catalog=TutorialsTeam;Integrated Security=True");
		    }
		}
	}
}
