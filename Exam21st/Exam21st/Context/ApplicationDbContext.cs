using Exam21st.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam21st.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

        } 


       public DbSet<OurServices> services {  get; set; }  
       public DbSet<AppUser> users { get; set; }
    }
}

