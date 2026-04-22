using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PinePawRetreat.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<OwnerModel> OwnerModels { get; set; }
        public DbSet<PetModel> PetModels { get; set; }
        public DbSet<BookingModel> BookingsModels { get; set; }
        public DbSet<PetBookingModel> PetBookingModels { get; set; }
        public DbSet<ContactModel> ContactModels { get; set; }
        public DbSet<VaccinationModel> vaccinationModels { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}