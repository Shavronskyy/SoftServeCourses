using System.ComponentModel.DataAnnotations;

namespace SoftServeTestTask_DAL.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

        //public DateTime CreationDate { get; set; }
    }
}
