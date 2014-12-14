using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TutionWeb1.Models.ViewModels.SubjectVM;
using TutorLib.Model;

namespace TutionWeb1.Models.ViewModels.ExaminationManagerVM
{
    public class ExamViewModel
    {
        [Display(Name = "Examination ID")]
        public decimal ExamID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Examination Name")]
        [Required(ErrorMessage = "Please enter examination name.")]
        public string ExamName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter examination description.")]
        public string ExamNote { get; set; }
        public Nullable<bool> IsPublished { get; set; }        
        public Nullable<bool> HasCommonEnroll { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Enrollment Key")]
        public string EnrollKey { get; set; }


        [Range(1, Int32.MaxValue, ErrorMessage = "Please Select Subject")]
        [Display(Name = "Subject")]
        public int SubjectID { get; set; }


        [Range(1, Int32.MaxValue, ErrorMessage = "Please Select Subject Category")]
        [Display(Name = "Subject Category")]
        public int SubjectCategoryID { get; set; }


        public Subject Subject { get; set; }
        public Nullable<decimal> TutorID { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        
    }
}