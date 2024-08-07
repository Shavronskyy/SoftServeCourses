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
                var message = "NewCourseDTO is null!";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var course = _mapper.Map<Course>(newCourse);

            course = await _courseRepository.CreateAsync(course);
            await _courseRepository.SaveChangesAsync();

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
                var message = "course notFound";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            _courseRepository.Delete(course);
            await _courseRepository.SaveChangesAsync();

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
            await _courseRepository.SaveChangesAsync();

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

            return _mapper.Map<CourseDTO>(course);
        }
    }
}
