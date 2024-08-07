using System.ComponentModel.DataAnnotations;

namespace SoftServeTestTask_DAL.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public List<Course> Courses { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}
