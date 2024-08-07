using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.Services.Interfaces.StudentServices;
using SoftServeTestTask_BLL.Services.Realizations.StudentServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.StudentRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_Tests.ServicesTests.StudentTests
{
    public class DeleteStudentStudentService
    {
        private readonly Mock<IStudentRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IStudentService _service;
        private readonly ILogger<StudentService> _logger;

        public DeleteStudentStudentService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<IStudentRepository>();
            _service = new StudentService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task DeleteStudent_ReturnsError_WhenInputZeroOrLess()
        {
            // Arrange
            var studentId = -1;
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteStudent(studentId));
        }

        [Fact]
        public async Task DeleteStudent_ReturnsError_WhenGetByIdReturnsNull()
        {
            // Arrange
            var studentId = 3;
            _repoMock.Setup(obj => obj.GetByIdAsync(studentId)).ReturnsAsync((Student)null!);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteStudent(studentId));
        }

        [Fact]
        public async Task DeleteStudent_ReturnsError_WhenSaveFailed()
        {
            // Arrange
            var studentId = 3;
            var student = new Student();
            _repoMock.Setup(obj => obj.GetByIdAsync(studentId)).ReturnsAsync(student);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            _repoMock.Setup(obj => obj.Delete(student));
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.DeleteStudent(studentId));
        }

        [Fact]
        public async Task DeleteStudent_ReturnsTrue_WhenDeletedSuccess()
        {
            // Arrange
            var studentId = 3;
            var student = new Student();
            _repoMock.Setup(obj => obj.GetByIdAsync(studentId)).ReturnsAsync(student);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _repoMock.Setup(obj => obj.Delete(student));

            // Act
            var result = await _service.DeleteStudent(studentId);

            // Assert
            Assert.True(result);

        }
    }
}
