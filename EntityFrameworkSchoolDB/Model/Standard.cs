using System.Collections.Generic;

namespace EntityFrameworkSchoolDB.Model
{
    public class Standard
    {
        public Standard()
        {
            Students = new List<Student>();
        }

        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}