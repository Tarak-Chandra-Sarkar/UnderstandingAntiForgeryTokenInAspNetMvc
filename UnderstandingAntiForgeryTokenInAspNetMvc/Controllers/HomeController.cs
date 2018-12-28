using System.Web.Mvc;
using UnderstandingAntiForgeryTokenInAspNetMvc.Filters;
using UnderstandingAntiForgeryTokenInAspNetMvc.Models;

namespace UnderstandingAntiForgeryTokenInAspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult Submit(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View("SubmitResult", model);
        }
    }
}