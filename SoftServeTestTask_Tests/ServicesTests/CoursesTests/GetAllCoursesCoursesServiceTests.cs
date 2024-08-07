using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_BLL.Services.Realizations.CourseServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_Tests.ServicesTests.CoursesTests
{
    public class GetAllCoursesCoursesServiceTests
    {
        private readonly Mock<ICourseRepository> _courseRepMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICourseService _service;
        private readonly ILogger<CourseService> _logger;

        public GetAllCoursesCoursesServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _courseRepMock = new Mock<ICourseRepository>();
            _service = new CourseService(_mapperMock.Object, _courseRepMock.Object, _logger);
        }

        [Fact]
        public async Task GetAllCourses_ReturnsSuccess()
        {
            // Arrange
            List<Course> courses = new();
            List<CourseDTO> coursesDto = new();
            _mapperMock.Setup(obj => obj.Map<IEnumerable<CourseDTO>>(courses)).Returns(coursesDto);
            _courseRepMock.Setup(obj => obj.GetAllAsync()).ReturnsAsync(new List<Course>());
            // Act
            var result = _service.GetAllCourses();

            // Assert
            Assert.NotNull(result);
        }
    }
}
