//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TutorLib.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.Choices = new HashSet<Choice>();
            this.StudentQuestions = new HashSet<StudentQuestion>();
        }
    
        public decimal QuesID { get; set; }
        public string Question1 { get; set; }
        public Nullable<int> QuestionType { get; set; }
        public decimal ExaminationID { get; set; }
    
        public virtual ICollection<Choice> Choices { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual ICollection<StudentQuestion> StudentQuestions { get; set; }
    }
}
