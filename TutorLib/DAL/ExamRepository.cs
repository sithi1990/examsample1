using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLib.Model;
using TutorLib.Helpers;

namespace TutorLib.DAL
{
    public class ExamRepository : IExamRepository
    {
        private EducLKDB2Entities1 db = new EducLKDB2Entities1();

        public bool CreateExam(Examination exam)
        {
            try
            {
                db.Examinations.Add(exam);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateExam(Examination exam)
        {
            try
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PublishExam(decimal ExamID, bool IsPublished)
        {
            try
            {
                db.sp_publish_exam(ExamID, IsPublished);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteExam(decimal ExamID)
        {
            try
            {
                Examination examination = db.Examinations.Find(ExamID);
                db.Examinations.Remove(examination);
                db.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }
            
            
        }

        int count;
        public IEnumerable<Examination> GetExams(decimal TutorID,int pageno,int pagesize)
        {
            count = db.Examinations.Where(e => e.TutorID == TutorID).Count();
            return db.Examinations.Where(e => e.TutorID == TutorID).OrderBy(e=>e.TutorID).Skip(SkipDataHelper.getSkippedNo(pageno,pagesize)).Take(pagesize);
        }

        public int getCount()
        {
            return count;
        }

        public IEnumerable<Examination> GetExams(decimal TutorID, decimal SubjectID, int pageno, int pagesize)
        {
            count = db.Examinations.Where(e => e.TutorID == TutorID && e.SubjectID == SubjectID).Count();
            int x = SkipDataHelper.getSkippedNo(pageno, pagesize);
            return db.Examinations.Where(e => e.TutorID == TutorID && e.SubjectID == SubjectID).OrderBy(e => e.TutorID).Skip(x).Take(pagesize);
        }


        public Examination GetSelected(int id)
        {
            return db.Examinations.Find(id);
        }
    }

    public interface IExamRepository
    {
        bool CreateExam(Examination exam);

        bool UpdateExam(Examination exam);

        bool PublishExam(decimal ExamID, bool IsBublished);

        bool DeleteExam(decimal ExamID);
        
        IEnumerable<Examination> GetExams(decimal TutorID,int pageno,int pagesize);

        IEnumerable<Examination> GetExams(decimal TutorID, decimal SubjectID,int pageno, int pagesize);

        Examination GetSelected(int id);

        int getCount();
       
       
    }
}
