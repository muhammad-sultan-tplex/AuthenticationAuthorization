using AuthenticationAuthorization.Authentication;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorization.Seed
{
    public class DataSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { UserName = "sultan", Email = "sultan@gmail.com", }
            );
        }
    }
}
