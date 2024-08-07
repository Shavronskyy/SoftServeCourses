

using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.Services.Interfaces.TeacherServices;
using SoftServeTestTask_BLL.Services.Realizations.TeacherServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;

namespace SoftServeTestTask_Tests.ServicesTests.TeacherTests
{
    public class DeleteTeacherTeacherService
    {
        private readonly Mock<ITeacherRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ITeacherService _service;
        private readonly ILogger<TeacherService> _logger;

        public DeleteTeacherTeacherService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<ITeacherRepository>();
            _service = new TeacherService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task DeleteTeacher_ReturnsError_WhenInputZeroOrLess()
        {
            // Arrange
            var teacherId = -1;
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteTeacher(teacherId));
        }

        [Fact]
        public async Task DeleteTeacher_ReturnsError_WhenGetByIdReturnsNull()
        {
            // Arrange
            var teacherId = 3;
            _repoMock.Setup(obj => obj.GetByIdAsync(teacherId)).ReturnsAsync((Teacher)null!);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteTeacher(teacherId));
        }

        [Fact]
        public async Task DeleteTeacher_ReturnsError_WhenSaveFailed()
        {
            // Arrange
            var teacherId = 3;
            var teacher = new Teacher();
            _repoMock.Setup(obj => obj.GetByIdAsync(teacherId)).ReturnsAsync(teacher);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            _repoMock.Setup(obj => obj.Delete(teacher));
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteTeacher(teacherId));
        }

        [Fact]
        public async Task DeleteTeacher_ReturnsTrue_WhenDeletedSuccess()
        {
            // Arrange
            var teacherId = 3;
            var teacher = new Teacher();
            _repoMock.Setup(obj => obj.GetByIdAsync(teacherId)).ReturnsAsync(teacher);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _repoMock.Setup(obj => obj.Delete(teacher));

            // Act
            var result = await _service.DeleteTeacher(teacherId);

            // Assert
            Assert.True(result);

        }
    }
}
