using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutionWeb1.Helpers;
using TutionWeb1.Models;
using TutionWeb1.Models.ViewModels.ExaminationManagerVM;
using TutionWeb1.Models.ViewModels.TutorVM;
using TutorLib.DAL;
using TutorLib.Model;
using TutorLib.Service;

namespace TutionWeb1.Controllers
{
    public class TutorController : Controller
    {
        //
        // GET: /Tutor/

        private ITutorService service;

        public TutorController()
        {
            service = new TutorService(new ModelStateWrapper(this.ModelState), new TutorRepository());
        }

        public TutorController(ITutorService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.DisplayPropVal = "none";
            return View();
        }

        [HttpPost]
        public ActionResult Create(TutorCreateViewModel vm)
        {
            Mapper.CreateMap<TutorCreateViewModel, Tutor>();
            var tutor = new Tutor();
            Mapper.Map<TutorCreateViewModel, Tutor>(vm, tutor);

            if (service.CreateTutor(tutor))
            {
                ViewBag.DisplayPropVal="block";
                return View();
            }

            return View(vm);
            
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "New")]
        public void New(TutorCreateViewModel mm) 
        {

            RedirectToAction("Create");
        }
	}
}