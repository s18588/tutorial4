using java.sql;
using org.joda.time;
using DateTime = System.DateTime;

namespace Tutorial4.Models
{
    public class Student
    {

        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Semester { get; set; }
        public string Studies { get; set; }
    }
}