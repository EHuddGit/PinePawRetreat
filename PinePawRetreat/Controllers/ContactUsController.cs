using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using PinePawRetreat.Models;
using PinePawRetreat.ViewModels;

namespace PinePawRetreat.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ContactForm()
        {
            return View(new ContactUsSubmissionVM());
        }

        public ActionResult ContactFormSubmitted()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactForm(ContactUsSubmissionVM submission)
        {

            ContactModel model = new ContactModel();

            model.NameFirst = submission.NameFirst;
            model.NameLast = submission.NameLast;
            model.Email = submission.Email;
            model.Subject = submission.Subject;
            model.Message = submission.Message;

            if (submission.PhoneNumber != null)
                model.PhoneNumber = submission.PhoneNumber;


            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                dbContext.ContactModels.Add(model);

                try
                {
                    dbContext.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return Content("error: could not submit contact form");
                }

            }
            return RedirectToAction("/ContactFormSubmitted");
        }
    }
}