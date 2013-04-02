using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeSCo.Models;

namespace DeSCo.Controllers
{
    public class TabTestController : Controller
    {
        //
        // GET: /TabTest/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetTabs(Tab tabClass)
        {
            string content = tabClass.ContentOne;
            return View();
        }

    }
}
