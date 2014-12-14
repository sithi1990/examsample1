using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using TutionWeb1.Models.ViewModels.SubjectVM;

namespace TutionWeb1.Models.ViewModels.ExaminationManagerVM
{
    public class ExaminationManagerViewModel
    {
        public ICollection<SubjectListViewModel> Subjects { get; set; }
        public IPagedList<ExamRowViewModel> Exams { get; set; }      
       
        public ExamViewModel Exam { get; set; }

    }
}