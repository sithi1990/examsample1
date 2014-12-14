using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLib.Model;

namespace TutorLib.DAL
{
    public class TutorRepository : ITutorRepository
    {
        private EducLKDB2Entities1 db = new EducLKDB2Entities1();

        public bool CreateTutor(Tutor tutor)
        {
            try
            {
                db.Tutors.Add(tutor);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public IEnumerable<Tutor> ListTutors()
        {
            return db.Tutors.ToList();
        }
    }

    public interface ITutorRepository
    {
        bool CreateTutor(Tutor tutor);
        IEnumerable<Tutor> ListTutors();
       
    }
}
