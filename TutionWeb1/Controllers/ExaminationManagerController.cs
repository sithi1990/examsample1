using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorLib.Model;
using PagedList;
using AutoMapper;
using TutorLib.Service;
using TutionWeb1.Models;
using TutorLib.DAL;
using TutionWeb1.Models.ViewModels.ExaminationManagerVM;
using TutionWeb1.Models.ViewModels.SubjectVM;

namespace TutionWeb1.Controllers
{
    public class ExaminationManagerController : Controller
    {
       

        private IExamService service_exam;
        private ISubjectService service_subject;
        private ISubjectCategoryService service_subject_category;

        private decimal KEY_TUTOR_ID = 10019;
        private string KEY_LANG = "en";
        private int KEY_PAGE_SIZE = 3;

        public ExaminationManagerController()
        {
            service_exam = new ExamService(new ModelStateWrapper(this.ModelState), new ExamRepository());
            service_subject = new SubjectService(new ModelStateWrapper(this.ModelState), new SubjectRepository());
            service_subject_category = new SubjectCategoryService(new ModelStateWrapper(this.ModelState), new SubjectCategoryRepository());
        }

        public ExaminationManagerController(IExamService service,ISubjectService ss,ISubjectCategoryService sc)
        {
            this.service_exam = service;
            this.service_subject = ss;
            this.service_subject_category = sc;
        }
        //
        // GET: /ExaminationManager/

        ExaminationManagerViewModel examinationdata;     
        public ActionResult Index(int? subject,int? page)
        {

            examinationdata = new ExaminationManagerViewModel();       
            ViewBag.SubjectCategoriyID = new SelectList(service_subject_category.GetSubjectCategories(KEY_LANG), "SubjectCategoryID", "SubjectCategoryName");
            fillTutorSubjectsList();
            fillExamsList(subject,page);
            return View(examinationdata);
           
        }

        private void fillExamsList(int? subject,int? page)
        {
            IEnumerable<Examination> exams;
            if(subject!=null)
            {
                exams = service_exam.GetExams(KEY_TUTOR_ID, subject ?? 0, page ?? 1, KEY_PAGE_SIZE).ToList();             
            }
            else
            {
                exams = service_exam.GetExams(KEY_TUTOR_ID, page ?? 1, KEY_PAGE_SIZE).ToList();                
            }

            Mapper.CreateMap<Examination, ExamRowViewModel>();
            IEnumerable<ExamRowViewModel> attachments = Mapper.Map<IEnumerable<Examination>, List<ExamRowViewModel>>(exams);
            examinationdata.Exams = new StaticPagedList<ExamRowViewModel>(attachments, page ?? 1, KEY_PAGE_SIZE, service_exam.getCount());
           
            
        }

        private void fillExamsList(int subjectid,int? page)
        {
            IEnumerable<Examination> exams = service_exam.GetExams(KEY_TUTOR_ID,subjectid, page ?? 1, KEY_PAGE_SIZE).ToList();
            Mapper.CreateMap<Examination, ExamRowViewModel>();
            IEnumerable<ExamRowViewModel> attachments = Mapper.Map<IEnumerable<Examination>, List<ExamRowViewModel>>(exams);
            examinationdata.Exams = new StaticPagedList<ExamRowViewModel>(attachments, page ?? 1, KEY_PAGE_SIZE, service_exam.getCount());
        }

        private void fillTutorSubjectsList()
        {
            IEnumerable<SubjectsResult> subjects_mod = service_subject.GetSubjectsByTutor(KEY_TUTOR_ID, KEY_LANG);
            Mapper.CreateMap<SubjectsResult, SubjectListViewModel>();
            var subjects = Mapper.Map<IEnumerable<SubjectsResult>, List<SubjectListViewModel>>(subjects_mod);
            examinationdata.Subjects = subjects;
        }

        public JsonResult SubjectsList(int Id)
        {
            try
            {
                var subjects = service_subject.GetSubjectsByCategory(Id,KEY_LANG).ToList();
                return Json(new SelectList(subjects.ToArray(), "SubjectID", "SubjectName"), JsonRequestBehavior.AllowGet);
            }
           catch 
           {
                return null;
            }
        }

       

        [HttpPost]
        public void Create(ExamViewModel vm)
        {

            if (ModelState.IsValid)
            {

                Mapper.CreateMap<ExamViewModel, Examination>();
                var exam = new Examination();
                Mapper.Map<ExamViewModel, Examination>(vm, exam);
                exam.TutorID = KEY_TUTOR_ID;
                service_exam.CreateExam(exam);              
                
            }
            Response.Redirect("Index");

        }


        [HttpPost]
        public void Change(ExamViewModel vm)
        {

            if (ModelState.IsValid)
            {
                Mapper.CreateMap<ExamViewModel, Examination>();
                var exam = new Examination();
                Mapper.Map<ExamViewModel, Examination>(vm, exam);
                exam.TutorID = KEY_TUTOR_ID;
                service_exam.UpdateExam(exam);
            }
            Response.Redirect("Index");

        }


        public ActionResult CreatePartial(int Id)
        {
            
            Examination exam = service_exam.GetSelected(Id);         
            Mapper.CreateMap<Examination, ExamViewModel>();
            var exam_maped = Mapper.Map<Examination, ExamViewModel>(exam);
            exam_maped.SubjectCategoryID = exam.Subject.SubjectCategoryID ?? 0;
            ViewBag.TestVal = exam_maped.SubjectID;

            ViewBag.SubjectCategoriyID = new SelectList(service_subject_category.GetSubjectCategories(KEY_LANG), "SubjectCategoryID", "SubjectCategoryName");
            ViewBag.SubjectID1 = new SelectList(service_subject.GetSubjectsByCategory(exam.Subject.SubjectCategoryID, KEY_LANG), "SubjectID", "SubjectName");
            return PartialView("_Change", exam_maped);
        }

        public ActionResult CreatePartialNew()
        {
            ViewBag.SubjectCategoriyID = new SelectList(service_subject_category.GetSubjectCategories(KEY_LANG), "SubjectCategoryID", "SubjectCategoryName");
            return PartialView("_Create", new ExamViewModel());
        }
       
	}
}