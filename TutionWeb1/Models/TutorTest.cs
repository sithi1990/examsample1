using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutionWeb1.Models
{
    public class TutorTest
    {
        public int ID;
        [Required]
        public string TutorName { get; set; }
    }
}