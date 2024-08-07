using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;

namespace SoftServeTestTask_BLL.DTO.CourseDTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<StudentDTO> Students { get; set; }

        public List<TeacherDTO> Teachers { get; set; }

        //public DateTime CreationDate { get; set; }
    }
}
