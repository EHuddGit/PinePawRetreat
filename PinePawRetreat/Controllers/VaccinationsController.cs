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
            VaccinationVM vm = new VaccinationVM();
            vm.petID = petId;
            return View(vm);
        }
        [HttpPost]
        public ActionResult AddVaccinations(VaccinationVM vacVM)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                VaccinationModel Vac = new VaccinationModel();
                Guid petIDGuid = Guid.Parse(vacVM.petID);

                Vac.PetID = petIDGuid;
                Vac.DatePerformed = vacVM.DatePerformed;
                Vac.DateDue = vacVM.DateDue;
                Vac.VaccName = vacVM.VaccName;
                Vac.VaccinationStatus = "Pending Review";
                Vac.Pet = dbContext.PetModels.SingleOrDefault(p => p.PetID == petIDGuid);

                if (Vac.Pet == null)
                    return Content("Invalid data for creating pet");

                dbContext.vaccinationModels.Add(Vac);
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return Content("Vaccination record submitted: " + Vac.VaccName + " Record for " + Vac.Pet.PetName);
            }
        }

        public ActionResult EditVaccinations()
        {
            return View();
        }
        public ActionResult ViewVaccinations(string petId)
        {
            ViewVaccinationsVM ViewVacVM = new ViewVaccinationsVM();
            List<ViewModels.VaccinationVM> vacVMs = new List<ViewModels.VaccinationVM>();
            Guid petIdGuid = Guid.Parse(petId);
            ViewVacVM.PetID = petId;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {

                //the lambda function is for sql only
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
            ViewVacVM.Vaccinations = vacVMs;
            return View(ViewVacVM);
        }

    }
}