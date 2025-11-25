using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class BookingsController : Controller
    {
        // GET: Bookings
        public enum State { Pending, Confirmed, CheckedIn, CheckedOut, Cancelled, Noshow };
        public ActionResult Index()
        {
            return View();
        }

        public bool BookingValidation(BookingModel booking)
        {
            bool validate = true;
           
            if (booking.PetBookingJoin == null || booking.PetBookingJoin.Count < 1)
                validate = false;
            if (booking.BookingStartTime >= booking.BookingEndTime)
                validate = false;
            if (booking.Owner == null)
                validate = false;


            return validate;
        }
        public static string CleanGuid(string input)
        {
            return input
                .Trim()
                .Replace("\u200B", "")
                .Replace("\u200C", "")
                .Replace("\u00AD", "")
                .Replace("–", "-")
                .Replace("—", "-");
        }

        public ActionResult Create(string startTime, string endTime, string ownerID, List<string> petIDs)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                BookingModel bookingModel = new BookingModel();
                Guid ownerGuid = Guid.Parse(ownerID);

                bookingModel.BookingStartTime = DateTime.Parse(startTime);
                bookingModel.BookingEndTime = DateTime.Parse(endTime);
                bookingModel.Status = State.Pending.ToString();
                bookingModel.Owner = dbContext.OwnerModels.FirstOrDefault(x => x.OwnerID == ownerGuid);

                if (bookingModel.PetBookingJoin == null)
                {
                    bookingModel.PetBookingJoin = new List<PetBookingModel>();
                }


                foreach (string petID in petIDs)
                {
                    Guid petGuid = Guid.Parse(CleanGuid(petID));
                    PetModel tempPet = dbContext.PetModels.FirstOrDefault(x => x.PetID == petGuid);
                    var debugList = dbContext.PetModels.ToList();

                    if (tempPet == null)
                        return Content("invalid pet data for booking");

                    PetBookingModel temp = new PetBookingModel(tempPet, bookingModel);
                    bookingModel.PetBookingJoin.Add(temp);
                }

                if (!BookingValidation(bookingModel))
                    return Content("invalid data for booking");

                dbContext.BookingsModels.Add(bookingModel);

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }



                return Content("Create");
            }
        }

        public ActionResult Delete(Guid id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                BookingModel booking = dbContext.BookingsModels.FirstOrDefault(x => x.BookingID == id);

                if (booking != null)
                {
                    var petJoinTable = dbContext.PetBookingModels.Where(x => x.Booking.BookingID == id).ToList();

                    if (petJoinTable.Any())
                        dbContext.PetBookingModels.RemoveRange(petJoinTable);

                    dbContext.BookingsModels.Remove(booking);

                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }

                    return Content("booking with id: " + id + " has been deleted");
                }
                else
                    return Content("booking not found, could not delete");
            }

        }
    }
}