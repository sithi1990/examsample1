using TutorLib.DAL;
using TutorLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorLib.IWrapers;

namespace TutorLib.Service
{
    public class TutorService : ITutorService       
    {
        private IValidationDictionary  modelstate;
        private ITutorRepository repository;

        public TutorService(IValidationDictionary modelstate, ITutorRepository repository)
        {
            this.modelstate = modelstate;
            this.repository = repository;

        }

        protected bool Validate(Tutor tutor)
        {
            
            if (tutor.FirstName==null)
                modelstate.AddError("FirstName", "First Name is required.");

            if (tutor.LastName == null)
                modelstate.AddError("LastName", "Last Name is required.");

            return modelstate.IsValid;
        }

        public bool CreateTutor(Tutor tutor)
        {
            if (Validate(tutor))
            {
                try
                {
                    repository.CreateTutor(tutor);
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

        public IEnumerable<Tutor> ListTutors()
        {
            return repository.ListTutors();
        }
    }

    public interface ITutorService
    {
        bool CreateTutor(Tutor productToCreate);
        IEnumerable<Tutor> ListTutors();
    }
}