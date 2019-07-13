using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenieAir.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public DateTime Registered { get; set; }
        
        [Display(Name = "User Roles")]
        public string UserRoles { get; set; }
        [Required]
        [Display(Name = "Sex")]
        public string Sex { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public System.Data.Entity.DbSet<flight_search> FlightSearchs { get; set; }
        public System.Data.Entity.DbSet<flight_users> FlightUsers { get; set; }
        public System.Data.Entity.DbSet<Card_Details> CardDetails { get; set; }
        public System.Data.Entity.DbSet<Passenger_Details> PassngerDetails { get; set; }
        public System.Data.Entity.DbSet<booking_details> Booking_Details { get; set; }
        public System.Data.Entity.DbSet<State> States { get; set; }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}