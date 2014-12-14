using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorLib.Model;

namespace TutionWeb1.Models.ViewModels.SubjectVM
{
    public class CascadeSubjectViewModel
    {
        public CascadeSubjectViewModel()
        {
            SubjectCategories = new List<SubjectCategory>();
        }
        public int? SelectedSubjectId { get; set; }
        public int? SelectedSubjectCategoryId { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<SubjectCategory> SubjectCategories { get; set; }
    }
}