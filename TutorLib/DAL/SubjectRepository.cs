using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLib.Model;

namespace TutorLib.DAL
{
    public class SubjectRepository : ISubjectRepository
    {
        private EducLKDB2Entities1 db = new EducLKDB2Entities1();

        public bool CreateSubject(Subject sub)
        {
            try
            {
                db.Subjects.Add(sub);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateSubject(Subject sub)
        {
            try
            {
                db.Entry(sub).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public bool DeleteSubject(decimal SubjectID)
        {
            try
            {
                Subject sub = db.Subjects.Find(SubjectID);
                db.Subjects.Remove(sub);
                db.SaveChanges();
                return true;
            }
            catch 
            { 
                return false; 
            }
            
            
        }

        public IEnumerable<SubjectsResult> GetSubjectsByTutor(decimal TutorID,string lang)
        {
            return db.sp_get_subjects_by_tutor(TutorID, lang);
        }

        public IEnumerable<SubjectsResult> GetSubjectsByCategory(int? CategoryID,string lang)
        {
            return db.sp_get_subjects(CategoryID, lang);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return db.Subjects.ToList<Subject>();
        }
    }

    public interface ISubjectRepository
    {
        bool CreateSubject(Subject sub);

        bool UpdateSubject(Subject sub);


        bool DeleteSubject(decimal SubjectID);

        IEnumerable<SubjectsResult> GetSubjectsByTutor(decimal TutorID, string lang);

        IEnumerable<SubjectsResult> GetSubjectsByCategory(int? CategoryID, string lang);

        IEnumerable<Subject> GetSubjects();
    }
}
