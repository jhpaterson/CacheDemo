using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using System.Threading;

namespace CacheDemo.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 10, VaryByParam = "none")]
        public ActionResult Index()
        {
            Response.Write("Index action is running: " + DateTime.Now.ToString("T"));
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Server)]
        public ActionResult GetNameServer()
        {
            Response.Write("GetNameServer action is running: " + DateTime.Now.ToString("T"));
            ViewBag.Result = "Hello " + User.Identity.Name;
            return View("Test");
        }

        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.Client, NoStore = false)]
        public ActionResult GetNameClient()
        {
            Response.Write("GetNameClient action is running: " + DateTime.Now.ToString("T"));
            ViewBag.Result = "Hello " + User.Identity.Name;
            return View("Test");
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "none")]
        public ActionResult List()
        {
            Response.Write("List action is running: " + DateTime.Now.ToString("T"));
            ViewBag.Result = "List of results";
            return View("Test");
        }

        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            Response.Write("Details action is running: " + DateTime.Now.ToString("T"));
            ViewBag.Result = "Details for id=" + id;
            return View("Test");
        }

      
        public ActionResult Parent()
        {
            Response.Write("Parent action is running: " + DateTime.Now.ToString("T"));

            return View();
        }

        [OutputCache(Duration = 30, VaryByParam = "none")]
        public ActionResult Child()
        {
            Response.Write("Child action is running: " + DateTime.Now.ToString("T"));

            return View();
        }

        [OutputCache(CacheProfile="Cache1Hour")]
        public ActionResult About()
        {
            Response.Write("About action is running: " + DateTime.Now.ToString("T"));
            return View();
        }
    }
}
