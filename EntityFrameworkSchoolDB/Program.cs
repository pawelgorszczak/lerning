using System;
using System.Linq;
using EntityFrameworkSchoolDB.Model;

namespace EntityFrameworkSchoolDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //var linqToEntityTestingClass = new Classes.L2EQueries();
            using (var ctx = new SchoolDbContext())
            {
                var student1 = new Student()
                {
                    StudentName = "Michal5",
                    DateOfBirth = DateTime.Now,
                    Height = 192,
                    Weight = 200
                };
                var address1 = new StudentAddress()
                {
                    Address1 = "Krakow",
                    Address2 = "Glogoczow",
                    City = "Krakow"
                };
                
                student1.StudentAddress = address1;
                ctx.Students.Add(student1);
                ctx.SaveChanges();
                
                var studentToDelete = (
                    from s in ctx.Students
                    where s.StudentId == 1
                    select s
                    ).SingleOrDefault<Student>();
                var studentToDelete_Address = (
                    from a in ctx.StudentAddresses
                    where a.StudentAddressId == studentToDelete.StudentId
                    select a
                    ).FirstOrDefault<StudentAddress>();
                studentToDelete.StudentAddress = studentToDelete_Address;
                Console.WriteLine("FirstOrDefault \n" + studentToDelete.StudentId + " " + studentToDelete.StudentName);
                ctx.Students.Remove(studentToDelete);
                ctx.SaveChanges();
                /*
                var student1_2 = (from student in ctx.Students
                    where student.StudentName == "Michal5"
                    select student).FirstOrDefault<Student>();
                ctx.Students.Remove(student1);
                Console.WriteLine("FirstOrDefault \n" + student1_2.StudentId + " " + student1_2.StudentName);
                ctx.SaveChanges();
                */
            }
            Console.ReadKey();
        }
    }
}
