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
    
    public partial class StudentQuestionChoice
    {
        public decimal SQCID { get; set; }
        public Nullable<decimal> StuQuesID { get; set; }
        public Nullable<decimal> SelectedChoiceID { get; set; }
    
        public virtual Choice Choice { get; set; }
        public virtual StudentQuestion StudentQuestion { get; set; }
    }
}
