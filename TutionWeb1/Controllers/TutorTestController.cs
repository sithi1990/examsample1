using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutionWeb1.Models;

namespace TutionWeb1.Controllers
{
    public class TutorTestController : Controller
    {
        //
        // GET: /Tutor/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TutorTest t)
        {
          
            return View();
        }
        
	}
}