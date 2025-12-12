using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTemplate.Models;

namespace WebAppTemplate.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOwner(string Name, string phoneNumber, string ownerEmail = null, string Address = null, string City = null, string State = null)
        { //proabably need a way to seperate this out from the action so i dont have to duplicate this create owner function in both here and registration page
            OwnerModel Owner = new OwnerModel();

            Owner.OwnerName = Name;
            Owner.OwnerPhoneNumber = phoneNumber;
            Owner.OwnerEmail = ownerEmail;
            Owner.Address = Address;
            Owner.City = City;
            Owner.State = State;

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {

                dbContext.OwnerModels.Add(Owner);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return Content("Owner Created, Owner ID: " + Owner.OwnerID);
            }
        }

        public ActionResult ReadOwnerAccount(Guid id)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                OwnerModel owner = dbContext.OwnerModels.FirstOrDefault(x => x.OwnerID == id);

                if (owner == null)
                {
                    return Content("no Owner Account found");
                }

                return Content("Owner - ID " + owner.OwnerID + " Name: " + owner.OwnerName + " Phone: " + owner.OwnerPhoneNumber + " email: " + owner.OwnerEmail);

            }
        }
    }
}