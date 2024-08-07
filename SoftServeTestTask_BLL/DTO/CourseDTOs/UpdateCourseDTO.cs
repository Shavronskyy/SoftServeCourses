using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.DTO.CourseDTOs
{
    public class UpdateCourseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
