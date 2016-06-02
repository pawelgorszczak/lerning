using System;
using System.Linq;
using EntityFrameworkSchoolDB.Model;

namespace EntityFrameworkSchoolDB.Classes
{
    class L2EQueries
    {
        public L2EQueries()
        {/*
            using (var ctx = new SchoolContext())
            {
                //First/FirstOrDeafault
                var student = (from s in ctx.Students
                               where s.StudentName == "Student1"
                               select s).FirstOrDefault<Student>();
                Console.WriteLine("FirstOrDefault \n" + student.StudentID + " " + student.StudentName);

                //Single/SingleOrDefault
                //If recond doesnt exist it will throw and exception
                try
                {
                    var student2 = (from s2 in ctx.Students
                                    where s2.StudentID == 111
                                    select s2).SingleOrDefault<Student>();
                    Console.WriteLine("SingleOrDefault \n" + student2.StudentID + " " + student2.StudentName);
                }
                catch(Exception ex)
                {                    
                    Console.WriteLine(ex.Message.ToString());
                }
                //GroupBy
                var students = from s in ctx.Students
                                group s by s.Standard into studentsByStandard
                                select studentsByStandard;
                int i = 0;
                foreach(var s in students)
                {
                    Console.WriteLine("GroupBy \n" + s.ToList()[i].StudentID);
                    i++;
                }
                //OrderBy
                var students2 =from s2 in ctx.Students
                               orderby s2.StudentName descending
                               select s2;
                Console.WriteLine("OrderBy");
                foreach (var s in students2)
                {
                    Console.WriteLine(s.StudentID + " " + s.StudentName);
                    i++;
                }
                //Anonymous Class result
                var projectionResult = from s in ctx.Students
                                        where s.StudentName == "Student1"
                                        select new
                                        {
                                            s.StudentName,
                                            s.Standard.StandardName,
                                            s.Courses
                                        };
                Console.WriteLine("Anonymous Class result");
                foreach (var p in projectionResult)
                {
                    Console.WriteLine(p.StudentName + " " + p.StandardName + " ");
                    foreach(var course in p.Courses)
                    {
                        Console.WriteLine("\t" + course.CourseName);
                    }
                }
                
                //Nested queries
                var nestedQuery = from s in ctx.Students
                                  from c in s.Courses
                                  where s.StandardId == 1
                                  orderby s.StudentName ascending
                                  select new
                                  {
                                      s.StudentName,
                                      c.CourseName
                                  };
                Console.WriteLine("Nested Query");
                foreach (var nsQ in nestedQuery)
                {
                    Console.WriteLine(nsQ.StudentName);
                    foreach (var course in nsQ.CourseName)
                    {
                        Console.WriteLine("\t" + course);
                    }

                }
                //INNER JOIN without inner join :)
                var studentsAttemptingToCourses = from c in ctx.Courses
                                  orderby c.CourseName ascending
                                  select new
                                  {
                                      c,
                                      c.Students                                      
                                  }
                                  ;
                Console.WriteLine("All students which are attempting to some courses");
                foreach (var nsQ in studentsAttemptingToCourses)
                {
                    Console.WriteLine(nsQ.c.CourseName);
                    foreach (var s in nsQ.Students)
                    {
                        Console.WriteLine("\t" + s.StudentName);
                    }
                }
            }
        */
        }
    }
}
