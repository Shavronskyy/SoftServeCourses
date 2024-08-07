using AutoMapper;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_DAL.Entities;

namespace SoftServeTestTask_BLL.Mapping.Courses
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<CourseDTO, CreateCourseDTO>().ReverseMap();
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            CreateMap<CourseDTO, UpdateCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
        }
    }
}
