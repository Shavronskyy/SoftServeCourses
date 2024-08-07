using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;

namespace SoftServeTestTask_BLL.DTO.StudentDTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public List<TeacherDTO> Teachers { get; set; }

        public List<CourseDTO> Courses { get; set; }
    }
}
