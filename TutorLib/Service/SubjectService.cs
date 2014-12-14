using TutorLib.DAL;
using TutorLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorLib.IWrapers;

namespace TutorLib.Service
{
    public class SubjectService : ISubjectService       
    {
        private IValidationDictionary  modelstate;
        private ISubjectRepository repository;

        public SubjectService(IValidationDictionary modelstate, ISubjectRepository repository)
        {
            this.modelstate = modelstate;
            this.repository = repository;

        }

        protected bool Validate(Subject sub)
        {

            //if (exam.FirstName == null)
            //    modelstate.AddError("FirstName", "First Name is required.");

            //if (exam.LastName == null)
            //    modelstate.AddError("LastName", "Last Name is required.");

            return modelstate.IsValid;
        }



        public bool CreateSubject(Subject sub)
        {
            if(Validate(sub))
            { 
                return repository.CreateSubject(sub); 
            }
            return false;
            
        }

        public bool UpdateSubject(Subject sub)
        {
            if (Validate(sub))
            {
                return repository.UpdateSubject(sub);
            }
            return false;
        }

        public bool DeleteSubject(decimal SubjectID)
        {
            return repository.DeleteSubject(SubjectID);
        }

        public IEnumerable<SubjectsResult> GetSubjectsByTutor(decimal TutorID, string lang)
        {
            return repository.GetSubjectsByTutor(TutorID,lang);
        }

        public IEnumerable<SubjectsResult> GetSubjectsByCategory(int? CategoryID,string lang)
        {
            return repository.GetSubjectsByCategory(CategoryID,lang);
        }


        public IEnumerable<Subject> GetSubjects()
        {
            return repository.GetSubjects();
        }
    }

    public interface ISubjectService
    {
        bool CreateSubject(Subject sub);

        bool UpdateSubject(Subject sub);

       
        bool DeleteSubject(decimal SubjectID);

        IEnumerable<SubjectsResult> GetSubjectsByTutor(decimal TutorID, string lang);

        IEnumerable<SubjectsResult> GetSubjectsByCategory(int? CategoryID, string lang);

        IEnumerable<Subject> GetSubjects();
      
    }
}