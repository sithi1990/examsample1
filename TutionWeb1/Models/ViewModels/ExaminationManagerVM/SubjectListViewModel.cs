using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutionWeb1.Models.ViewModels.ExaminationManagerVM
{
    public class SubjectListViewModel
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsSelected { get; set; }

    }
}