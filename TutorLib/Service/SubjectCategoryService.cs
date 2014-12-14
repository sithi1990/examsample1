using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorLib.DAL;
using TutorLib.IWrapers;
using TutorLib.Model;

namespace TutorLib.Service
{
    public class SubjectCategoryService : ISubjectCategoryService
    {
         private IValidationDictionary  modelstate;
        private  ISubjectCategoryRepository repository;

        public SubjectCategoryService(IValidationDictionary modelstate, ISubjectCategoryRepository repository)
        {
            this.modelstate = modelstate;
            this.repository = repository;

        }

        protected bool Validate(SubjectService sub)
        {

            //if (exam.FirstName == null)
            //    modelstate.AddError("FirstName", "First Name is required.");

            //if (exam.LastName == null)
            //    modelstate.AddError("LastName", "Last Name is required.");

            return modelstate.IsValid;
        }

        public IEnumerable<SubjectCategoriesReturn> GetSubjectCategories(string lang)
        {
            return repository.GetSubjectCategories(lang);
        }
    }
    public interface ISubjectCategoryService
    {
        IEnumerable<SubjectCategoriesReturn> GetSubjectCategories(string lang);
    }
}
