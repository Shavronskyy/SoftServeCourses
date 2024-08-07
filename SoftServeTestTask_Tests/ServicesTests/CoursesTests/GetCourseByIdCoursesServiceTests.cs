using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_BLL.Services.Realizations.CourseServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;
using Xunit;

namespace SoftServeTestTask_Tests.ServicesTests.CoursesTests
{
    public class GetCourseByIdCoursesServiceTests
    {
        private readonly Mock<ICourseRepository> _courseRepMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICourseService _service;
        private readonly ILogger<CourseService> _logger;

        public GetCourseByIdCoursesServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _courseRepMock = new Mock<ICourseRepository>();
            _service = new CourseService(_mapperMock.Object, _courseRepMock.Object, _logger);
        }

        [Fact]
        public async Task GetCourseById_ReturnsError_WhenReturnsNull()
        {
            // Arrange
            _courseRepMock.Setup(obj => obj.GetByIdAsync(default)).ReturnsAsync((Course)null!);
            var searchedId = 1;

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetCourseById(searchedId));
        }

        [Fact]
        public async Task GetCourseById_ReturnsError_WhenInputZeroOrLess()
        {
            // Arrange
            _courseRepMock.Setup(obj => obj.GetByIdAsync(default)).ReturnsAsync(new Course());
            var searchedId = -1;

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetCourseById(searchedId));
        }

        [Fact]
        public async Task GetCourseById_ReturnCorrectCourse_WhenInputValidData()
        {
            // Arrange
            var course = new Course()
            {
                Id = 1
            };
            var courseDTO = new CourseDTO()
            {
                Id = 1,
            };
            var searchedId = 1;
            _courseRepMock.Setup(obj => obj.GetByIdAsync(searchedId)).ReturnsAsync(course);
            _mapperMock.Setup(obj => obj.Map<CourseDTO>(course)).Returns(courseDTO);

            // Assert
            var result = await _service.GetCourseById(searchedId);

            // Act
            Assert.Equal(searchedId, result.Id);
        }
    }
}
