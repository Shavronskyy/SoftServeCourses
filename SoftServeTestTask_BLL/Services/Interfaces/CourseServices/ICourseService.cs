using SoftServeTestTask_BLL.DTO.CourseDTOs;

namespace SoftServeTestTask_BLL.Services.Interfaces.CourseServices
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCourses();
        Task<CourseDTO> CreateCourse(CreateCourseDTO newCourse);
        Task<bool> DeleteCourse(int Id);
        Task<CourseDTO> UpdateCourse(UpdateCourseDTO updateCourse);
        Task<CourseDTO> GetCourseById(int Id);
    }
}
