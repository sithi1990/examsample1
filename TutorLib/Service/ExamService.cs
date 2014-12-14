using TutorLib.DAL;
using TutorLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorLib.IWrapers;

namespace TutorLib.Service
{
    public class ExamService : IExamService       
    {
        private IValidationDictionary  modelstate;
        private IExamRepository repository;

        public ExamService(IValidationDictionary modelstate, IExamRepository repository)
        {
            this.modelstate = modelstate;
            this.repository = repository;

        }

        protected bool Validate(Examination exam)
        {

            //if (exam.FirstName == null)
            //    modelstate.AddError("FirstName", "First Name is required.");

            //if (exam.LastName == null)
            //    modelstate.AddError("LastName", "Last Name is required.");

            return modelstate.IsValid;
        }

        public bool CreateExam(Examination exam)
        {
            if (Validate(exam))
            {
                try
                {
                    repository.CreateExam(exam);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool UpdateExam(Examination exam)
        {
            if (Validate(exam))
            {
                try
                {
                    repository.UpdateExam(exam);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool PublishExam(decimal ExamID, bool IsPublished)
        {
            return repository.PublishExam(ExamID,IsPublished);
        }

        public bool DeleteExam(decimal ExamID)
        {
            return repository.DeleteExam(ExamID);
        }

        public IEnumerable<Examination> GetExams(decimal TutorID,int pageno,int pagesize)
        {
            return repository.GetExams(TutorID,pageno,pagesize);
        }

        public IEnumerable<Examination> GetExams(decimal TutorID, decimal SubjectID, int pageno, int pagesize)
        {
            return repository.GetExams(TutorID,SubjectID,pageno,pagesize);
        }


        public Examination GetSelected(int id)
        {
            return repository.GetSelected(id);
        }


        public int getCount()
        {
            return repository.getCount();
        }
    }

    public interface IExamService
    {
        bool CreateExam(Examination exam);

        bool UpdateExam(Examination exam);

        bool PublishExam(decimal ExamID, bool IsBublished);

        bool DeleteExam(decimal ExamID);

        IEnumerable<Examination> GetExams(decimal TutorID, int pageno, int pagesize);

        IEnumerable<Examination> GetExams(decimal TutorID, decimal SubjectID, int pageno, int pagesize);

        Examination GetSelected(int id);

        int getCount();
        
      
    }
}