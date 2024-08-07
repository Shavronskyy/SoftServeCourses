using AutoMapper;
using Microsoft.Extensions.Logging;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;

namespace SoftServeTestTask_BLL.Services.Realizations.CourseServices
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseService> _logger;

        public CourseService(IMapper mapper, ICourseRepository courseRepository, ILogger<CourseService> logger)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public async Task<CourseDTO> CreateCourse(CreateCourseDTO newCourse)
        {
            if(newCourse is null)
            {
                var message = "NewCourseDTO is null";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var course = _mapper.Map<Course>(newCourse);    
            if (course is null)
            {
                var message = "course is null";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            course = await _courseRepository.CreateAsync(course);
            var result = await _courseRepository.SaveChangesAsync();
            if (result <= 0)
            {
                var message = "Save changes error, when attempt to create course";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var response = _mapper.Map<CourseDTO>(course);

            return response;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<bool> DeleteCourse(int Id)
        {
            if (Id <= 0)
            {
                var message = "id is <= than zero";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }
            var course = await _courseRepository.GetByIdAsync(Id);
            if(course is null)
            {
                var message = "course not found";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            _courseRepository.Delete(course);
            var result = await _courseRepository.SaveChangesAsync();
            if (result <= 0)
            {
                var message = "Save changes error, when attempt to delete course";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            return true;
        }

        public async Task<CourseDTO> UpdateCourse(UpdateCourseDTO updateCourse)
        {
            if(updateCourse is null)
            {
                var message = "UpdateCourse is null!";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var course = _mapper.Map<Course>(updateCourse);

            _courseRepository.Update(course);
            var result = await _courseRepository.SaveChangesAsync();
            if(result <= 0)
            {
                var message = "Save changes error, when attempt to update course";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }
            return _mapper.Map<CourseDTO>(course); 
        }

        public async Task<CourseDTO> GetCourseById(int Id)
        {
            if(Id <= 0)
            {
                var message = "id is <= than zero";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var course = await _courseRepository.GetByIdAsync(Id);

            if (course is null)
            {
                var message = "Course not found";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            return _mapper.Map<CourseDTO>(course);
        }
    }
}
