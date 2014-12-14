using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TutorLib.Model;
using System.ComponentModel.DataAnnotations;

namespace TutionWeb1.Models.ViewModels.ExaminationManagerVM
{
    public class ExamRowViewModel
    {

        [Display(Name="Examination ID")]
        public decimal ExamID { get; set; }

        [Display(Name = "Examination Name")]
        public string ExamName { get; set; }

        [Display(Name = "Description")]
        public string ExamNote { get; set; }
        public Nullable<bool> IsPublished { get; set; }
        public Nullable<bool> HasCommonEnroll { get; set; }
        public string EnrollKey { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public Nullable<decimal> TutorID { get; set; }

        [Display(Name = "Subject")]
        public virtual Subject Subject { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<StudentExam> StudentExams { get; set; }
    }
}