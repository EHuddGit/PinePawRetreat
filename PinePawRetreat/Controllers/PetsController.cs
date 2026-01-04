using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PinePawRetreat.Models;
using PinePawRetreat.ViewModels;

namespace PinePawRetreat.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Index()
        {
            List<ViewModels.PetVM> petVMs = new List<ViewModels.PetVM>();
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
              
                //the lambda function is for sql only
                string userEmail = User.Identity.GetUserName();
                var user = dbContext.OwnerModels.FirstOrDefault(u => u.OwnerEmail == userEmail);
                var pets = dbContext.PetModels
                    .Include("Owner")
                    .Where(p => p.Owner.OwnerID == user.OwnerID)
                    .ToList();
                //need to make a query about bookings with the specific pets and add a field about being boarding ready to db
                if (pets != null)
                {
                  
                    foreach (var Pet in pets)
                    {
                        ViewModels.PetVM temp = new ViewModels.PetVM();
                        temp.petID = Pet.PetID.ToString();
                        temp.Age = Pet.Age;
                        temp.Breed = Pet.Breed;
                        temp.Name = Pet.PetName;
                        temp.Sex = Pet.Sex;
                        // static data, should switch it out
                        temp.Boarding_Ready = "Boarding Ready";
                        temp.NextStay = "March 12 - March 16";
                        petVMs.Add(temp);
                    }
                }
            }
                return View(petVMs);
        }

        //change to guid later
        public ActionResult EditPet(string petId)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {

                Guid petIdGuid = Guid.Parse(petId);
                var pet = dbContext.PetModels.FirstOrDefault(p => p.PetID == petIdGuid);
                ViewModels.PetVM temp = new ViewModels.PetVM();
                if(pet == null) 
                {
                    RedirectToAction("Index");
                }   

                temp.petID = pet.PetID.ToString();
                temp.Age = pet.Age;
                temp.Breed = pet.Breed;
                temp.Name = pet.PetName;
                temp.Sex = pet.Sex;
                temp.Color = pet.Color;
                temp.DietaryRequirements = pet.DietaryRequirements;
                temp.MedicationRequirements = pet.MedicationRequirements;
                // static data, should switch it out
                temp.Boarding_Ready = "Boarding Ready";
                temp.NextStay = "March 12 - March 16";

                
                return View(temp);
            }
        }

        [HttpPost]
        public ActionResult EditPet(PetVM petVM)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {

                Guid petIdGuid = Guid.Parse(petVM.petID);
                var pet = dbContext.PetModels.FirstOrDefault(p => p.PetID == petIdGuid);
                if (pet == null)
                {
                    RedirectToAction("Index");
                }

                pet.Age = petVM.Age;
                pet.Breed = petVM.Breed;
                pet.PetName = petVM.Name;
                pet.Sex = petVM.Sex;
                pet.Color = petVM.Color;
                pet.DietaryRequirements = petVM.DietaryRequirements;
                pet.MedicationRequirements = petVM.MedicationRequirements;

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }



                return RedirectToAction("Index");
            }
        }

        public ActionResult ViewPet(string petId)
        {
            return View();
        }

        public ActionResult AddPet()
        {
            PetVM pet = new PetVM();
            return View(pet);
        }

        [HttpPost]
        public ActionResult AddPet(PetVM petVm)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                PetModel Pet = new PetModel();
                string userEmail = User.Identity.GetUserName();
                var user = dbContext.OwnerModels.FirstOrDefault(u => u.OwnerEmail == userEmail);
                Guid OwnerGuid = user.OwnerID;

                Pet.PetName = petVm.Name;
                Pet.Breed = petVm.Breed;
                Pet.Sex = petVm.Sex;
                Pet.Age = petVm.Age;
                Pet.Color = petVm.Color;
                Pet.DietaryRequirements = petVm.DietaryRequirements;
                Pet.MedicationRequirements = petVm.MedicationRequirements;
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

        [HttpPost]
        public ActionResult AddPetURL(string OwnerID, string Name, string Breed, string Sex, string Age = null,
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