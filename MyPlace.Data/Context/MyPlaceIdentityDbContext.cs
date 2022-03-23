using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyPlace.Data
{
    public class MyPlaceIdentityDbContext : IdentityDbContext {

        public MyPlaceIdentityDbContext(DbContextOptions<MyPlaceIdentityDbContext> options) : base(options) { }

    }
}