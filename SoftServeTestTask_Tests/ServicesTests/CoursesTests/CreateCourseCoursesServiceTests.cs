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
    public class CreateCourseCoursesServiceTests
    {
        private readonly Mock<ICourseRepository> _courseRepMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICourseService _service;
        private readonly ILogger<CourseService> _logger;

        public CreateCourseCoursesServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _courseRepMock = new Mock<ICourseRepository>();
            _service = new CourseService(_mapperMock.Object, _courseRepMock.Object, _logger);
        }

        [Fact]
        public async Task CreateCourse_ReturnsError_WhenInputNull()
        {
            // Arrange

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateCourse(null!));
        }

        [Fact]
        public async Task CreateCourse_ReturnsError_WhenMapperReturnNull()
        {
            // Arrange
            var newCourse = new CreateCourseDTO();
            var courseDto = new CourseDTO();
            
            _mapperMock.Setup(obj => obj.Map<Course>(courseDto)).Returns((Course)null!);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateCourse(newCourse));
        }

        [Fact]
        public async Task CreateCourse_ReturnsError_WhenSaveChangesFailed()
        {
            // Arrange
            var newCourse = new CreateCourseDTO();
            var courseDto = new CourseDTO();
            var course = new Course();

            _mapperMock.Setup(obj => obj.Map<Course>(newCourse)).Returns(course);
            _courseRepMock.Setup(obj => obj.CreateAsync(course));
            _courseRepMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateCourse(newCourse));
        }

        [Fact]
        public async Task CreateCourse_ReturnsSuccess_WhenInputCorrectData()
        {
            // Arrange
            var expectedTitle = "string";
            var newCourse = new CreateCourseDTO();
            var courseDto = new CourseDTO() { Title = expectedTitle };
            var course = new Course();

            _mapperMock.Setup(obj => obj.Map<Course>(newCourse)).Returns(course);
            _courseRepMock.Setup(obj => obj.CreateAsync(course)).ReturnsAsync(course);
            _courseRepMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _mapperMock.Setup(obj => obj.Map<CourseDTO>(course)).Returns(courseDto);

            // Act
            var result = await _service.CreateCourse(newCourse);

            // Assert 
            Assert.Equal(expectedTitle, result.Title);
        }
    }
}
