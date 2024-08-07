using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.DTO.StudentDTOs;

namespace SoftServeTestTask_BLL.DTO.TeacherDTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<StudentDTO> Students { get; set; }
        public List<CourseDTO> Courses { get; set; }

    }
}
