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
    public class UpdateCourseCoursesServiceTests
    {
        private readonly Mock<ICourseRepository> _courseRepMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICourseService _service;
        private readonly ILogger<CourseService> _logger;

        public UpdateCourseCoursesServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _courseRepMock = new Mock<ICourseRepository>();
            _service = new CourseService(_mapperMock.Object, _courseRepMock.Object, _logger);
        }

        [Fact]
        public async Task UpdateCourse_ReturnsError_WhenSaveFailed()
        {
            // Arrange
            var course = new Course();
            var UpdCourse = new UpdateCourseDTO();
            _mapperMock.Setup(obj => obj.Map<Course>(UpdCourse)).Returns(course);
            _courseRepMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            _courseRepMock.Setup(obj => obj.Update(course));
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateCourse(UpdCourse));
        }

        [Fact]
        public async Task UpdateCourse_ReturnsSuccess_WhenSaveSuccess()
        {
            // Arrange
            var expectedId = 2;
            var course = new Course();
            var UpdCourse = new UpdateCourseDTO();
            var courseDto = new CourseDTO() { Id = expectedId };

            _mapperMock.Setup(obj => obj.Map<Course>(UpdCourse)).Returns(course);
            _courseRepMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _courseRepMock.Setup(obj => obj.Update(course));
            _mapperMock.Setup(obj => obj.Map<CourseDTO>(course)).Returns(courseDto);

            // Act
            var result = await _service.UpdateCourse(UpdCourse);

            // Assert
            Assert.Equal(expectedId, courseDto.Id);

        }

    }
}
