using System;
using System.Collections.Generic;

namespace EntityFrameworkSchoolDB.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        public float Weight { get; set; }

        //one to one or zero relation
        //A student can have only one or zero address
        public virtual StudentAddress StudentAddress { get; set; }

        //One to Many relation
        //Standard can include many Students
        public virtual Standard Standard { get; set; }

        //many to many relation
        //Student can join multiple courses and multiple students can join one course
        public virtual ICollection<Course> Courses { get; set; }
    }
}

/* Data anauctions
       public int StudentId { get; set; }
       public string StudentName { get; set; }
       public DateTime? DateOfBirth { get; set; }
       public byte[] Photo { get; set; }
       public decimal Height { get; set; }
       public float Weight { get; set; }
       public int? StandardId { get; set; }
       public int? TeacherId { get; set; }

       [Timestamp]
       public byte[] RowVersion { get; set; }

       [ForeignKey("TeacherId")]
       public virtual Teacher Teacher { get; set; }

       [ForeignKey("StandardId")]
       public virtual Standard Standard { get; set; }
       */