using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            return View();
        }
        //things for validation, make sure validation sex
        public ActionResult CreatePet(string OwnerID, string Name, string Breed, string Sex, string Age = null,
            string Color = null, string DietaryReq = null, string medReq = null)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                PetModel Pet = new PetModel();
                Guid OwnerGuid = Guid.Parse(OwnerID);


                Pet.PetName = Name;
                Pet.Breed = Breed;
                Pet.Sex = Sex;
                Pet.Age = Age;
                Pet.Color = Color;
                Pet.DietaryRequirements = DietaryReq;
                Pet.MedicationRequirements = medReq;
                Pet.Owner = dbContext.OwnerModels.FirstOrDefault(x => x.OwnerID == OwnerGuid);

                if (Pet.Owner == null)
                    return Content("Invalid data for creating pet");

                dbContext.PetModels.Add(Pet);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return Content("Owner Created: Pet Name: " + Pet.PetName + " Owner ID: " + Pet.Owner.OwnerID + " Breed: " + Pet.Breed + " Sex: " + Pet.Sex);
            }
        }

        public ActionResult ReadPet(Guid id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {

                PetModel pet = dbContext.PetModels
                    .FirstOrDefault(x => x.PetID == id);

                if (pet == null)
                {
                    return Content("No Pet found");
                }

                return Content("Pet - ID " + pet.PetID + " Name: " + pet.PetName + " Breed: " + pet.Breed + " Sex: " + pet.Sex + " Age: " + pet.Age +
                    " Color: " + pet.Color + " Owner Name: " + pet.Owner.OwnerName + " Owner Phone: " + pet.Owner.OwnerPhoneNumber + " Owner Email: " + pet.Owner.OwnerEmail);
            }
        }

        public ActionResult DeletePet(Guid id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                PetModel Pet = dbContext.PetModels.FirstOrDefault(x => x.PetID == id);
                if (Pet != null)
                {
                    var bookingJoinTable = dbContext.PetBookingModels.Where(x => x.Pet.PetID == id).ToList();

                    var bookingIDs = dbContext.PetBookingModels.Where(x => x.Pet.PetID == id).
                        Select(x => x.Booking.BookingID).
                        Distinct().
                        ToList();

                    var bookings = dbContext.BookingsModels.Where(b => bookingIDs.Contains(b.BookingID)).ToList();

                    if (bookingJoinTable.Any())
                        dbContext.PetBookingModels.RemoveRange(bookingJoinTable);

                    if (bookings.Any())
                        dbContext.BookingsModels.RemoveRange(bookings);

                    dbContext.PetModels.Remove(Pet);

                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                    return Content("Successfully deleted pet " + Pet.PetName + " with id:" + Pet.PetID);
                }
                else
                    return Content("could not find pet, did not delete");

            }

        }
    }
}