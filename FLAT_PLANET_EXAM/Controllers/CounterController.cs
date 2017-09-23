using System.Web.Mvc;
using FLAT_PLANET_EXAM.Models;

namespace FLAT_PLANET_EXAM.Controllers
{
    public class CounterController : Controller
    {
        public ActionResult Index()
        {
            Counter objCounter = new Counter();
            ViewBag.ctr = objCounter.RetrieveCounter();

            return View();
        }
        public ActionResult NewCounter()
        {
            Counter objCounter = new Counter();

            if (objCounter.RetrieveCounter() < 10)
            {
                objCounter.UpdateCounter();
            }

            return RedirectToAction("Index");
        }
    }
}