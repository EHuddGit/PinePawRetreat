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
            return View((object)petId);
        }

    }
}