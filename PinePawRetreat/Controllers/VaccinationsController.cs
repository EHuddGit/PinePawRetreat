using Microsoft.AspNet.Identity;
using PinePawRetreat.Models;
using PinePawRetreat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PinePawRetreat.Controllers
{
    public class VaccinationsController : Controller
    {
        // GET: Vaccinations
        public ActionResult AddVaccinations(string petId)
        {
            return View((object)petId);
        }

        public ActionResult EditVaccinations()
        {
            return View();
        }
        public ActionResult ViewVaccinations(string petId)
        {
            List<ViewModels.VaccinationVM> vacVMs = new List<ViewModels.VaccinationVM>();
            Guid petIdGuid = Guid.Parse(petId);
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {

                //the lambda function is for sql only
                //var pet = dbContext.PetModels.FirstOrDefault(u => u.PetID == petIdGuid);
                var vaccinations = dbContext.vaccinationModels
                    .Where(p => p.PetID == petIdGuid)
                    .ToList();
                //need to make a query about bookings with the specific pets and add a field about being boarding ready to db
                if (vaccinations != null)
                {

                    foreach (var vac in vaccinations)
                    {
                        ViewModels.VaccinationVM temp = new ViewModels.VaccinationVM();
                        temp.DateDue = vac.DateDue;
                        temp.DatePerformed = vac.DatePerformed;
                        temp.VerifiedStatus = vac.VaccinationStatus;
                        temp.VaccName = vac.VaccName;
                        vacVMs.Add(temp);
                    }
                }
            }
            return View(vacVMs);
        }

    }
}