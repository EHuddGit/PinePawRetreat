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
        public ActionResult Index()
        {
            return View();
        }
    }
}