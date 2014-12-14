using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLib.Model;

namespace TutorLib.DAL
{
    public class SubjectCategoryRepository: ISubjectCategoryRepository
    {
        private EducLKDB2Entities1 db = new EducLKDB2Entities1();

        public IEnumerable<SubjectCategoriesReturn> GetSubjectCategories(string lang)
        {

            return db.sp_get_subject_categories(lang);

        }
    }
    public interface ISubjectCategoryRepository
    {
        IEnumerable<SubjectCategoriesReturn> GetSubjectCategories(string lang);
    }
}
