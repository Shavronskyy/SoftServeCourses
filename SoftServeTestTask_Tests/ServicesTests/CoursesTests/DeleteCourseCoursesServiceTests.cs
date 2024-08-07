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
    public class DeleteCourseCoursesServiceTests
    {
        private readonly Mock<ICourseRepository> _courseRepMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICourseService _service;
        private readonly ILogger<CourseService> _logger;

        public DeleteCourseCoursesServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _courseRepMock = new Mock<ICourseRepository>();
            _service = new CourseService(_mapperMock.Object, _courseRepMock.Object, _logger);
        }

        [Fact]
        public async Task DeleteCourse_ReturnsError_WhenInputZeroOrLess()
        {
            // Arrange
            var courseId = -1;
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteCourse(courseId));
        }

        [Fact]
        public async Task DeleteCourse_ReturnsError_WhenGetByIdReturnsNull()
        {
            // Arrange
            var courseId = 1;
            _courseRepMock.Setup(obj => obj.GetByIdAsync(courseId)).ReturnsAsync((Course)null!);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteCourse(courseId));
        }

        [Fact]
        public async Task DeleteCourse_ReturnsError_WhenSaveFailed()
        {
            // Arrange
            var courseId = 3;
            var course = new Course();
            _courseRepMock.Setup(obj => obj.GetByIdAsync(courseId)).ReturnsAsync(course);
            _courseRepMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            _courseRepMock.Setup(obj => obj.Delete(course));
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteCourse(courseId));
        }

        [Fact]
        public async Task DeleteCourse_ReturnsTrue_WhenDeletedSuccess()
        {
            // Arrange
            var courseId = 3;
            var course = new Course();
            _courseRepMock.Setup(obj => obj.GetByIdAsync(courseId)).ReturnsAsync(course);
            _courseRepMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _courseRepMock.Setup(obj => obj.Delete(course));

            // Act
            var result = await _service.DeleteCourse(courseId);

            // Assert
            Assert.True(result);
        }
    }
}
