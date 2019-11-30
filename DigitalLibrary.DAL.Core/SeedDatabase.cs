using System;
using DigitalLibrary.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalLibrary
{
    public static class SeedDatabase
    {
	    public static void Initialize(IServiceProvider serviceProvider)
	    {
		    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
		    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
		    context.Database.EnsureCreated();

		    if (context.Users.Any()) return;

		    var user = new ApplicationUser()
		    {
			    Email = "admin@gmail.com",
			    SecurityStamp = Guid.NewGuid().ToString(),
			    UserName = "Admin",
		    };

		    var result = userManager.CreateAsync(user, "Admin_123");
	    }
    }
}
