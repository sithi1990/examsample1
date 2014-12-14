﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EducLKDB2Entities1 : DbContext
    {
        public EducLKDB2Entities1()
            : base("name=EducLKDB2Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectCategory> SubjectCategories { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionStatu> QuestionStatus { get; set; }
        public virtual DbSet<StudentExam> StudentExams { get; set; }
        public virtual DbSet<StudentQuestion> StudentQuestions { get; set; }
        public virtual DbSet<StudentQuestionChoice> StudentQuestionChoices { get; set; }
    
        public virtual int sp_publish_exam(Nullable<decimal> examid, Nullable<bool> ispublished)
        {
            var examidParameter = examid.HasValue ?
                new ObjectParameter("examid", examid) :
                new ObjectParameter("examid", typeof(decimal));
    
            var ispublishedParameter = ispublished.HasValue ?
                new ObjectParameter("ispublished", ispublished) :
                new ObjectParameter("ispublished", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_publish_exam", examidParameter, ispublishedParameter);
        }
    
        public virtual ObjectResult<SubjectCategoriesReturn> sp_get_subject_categories(string lang)
        {
            var langParameter = lang != null ?
                new ObjectParameter("lang", lang) :
                new ObjectParameter("lang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SubjectCategoriesReturn>("sp_get_subject_categories", langParameter);
        }
    
        public virtual ObjectResult<SubjectsResult> sp_get_subjects(Nullable<int> sub_cat_id, string lang)
        {
            var sub_cat_idParameter = sub_cat_id.HasValue ?
                new ObjectParameter("sub_cat_id", sub_cat_id) :
                new ObjectParameter("sub_cat_id", typeof(int));
    
            var langParameter = lang != null ?
                new ObjectParameter("lang", lang) :
                new ObjectParameter("lang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SubjectsResult>("sp_get_subjects", sub_cat_idParameter, langParameter);
        }
    
        public virtual ObjectResult<SubjectsResult> sp_get_subjects_by_tutor(Nullable<decimal> tutorId, string lang)
        {
            var tutorIdParameter = tutorId.HasValue ?
                new ObjectParameter("TutorId", tutorId) :
                new ObjectParameter("TutorId", typeof(decimal));
    
            var langParameter = lang != null ?
                new ObjectParameter("lang", lang) :
                new ObjectParameter("lang", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SubjectsResult>("sp_get_subjects_by_tutor", tutorIdParameter, langParameter);
        }
    }
}
