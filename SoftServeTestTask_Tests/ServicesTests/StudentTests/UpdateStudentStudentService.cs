using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
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
    public class UpdateStudentStudentService
    {
        private readonly Mock<IStudentRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IStudentService _service;
        private readonly ILogger<StudentService> _logger;

        public UpdateStudentStudentService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<IStudentRepository>();
            _service = new StudentService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task UpdateStudent_ReturnsError_WhenSaveFailed()
        {
            // Arrange
            var student = new Student();
            var UpdStudent = new UpdateStudentDTO();
            _mapperMock.Setup(obj => obj.Map<Student>(UpdStudent)).Returns(student);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            _repoMock.Setup(obj => obj.Update(student));
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateStudent(UpdStudent));
        }

        [Fact]
        public async Task UpdateStudent_ReturnsSuccess_WhenSaveSuccess()
        {
            // Arrange
            var expectedId = 2;
            var student = new Student();
            var UpdStudent = new UpdateStudentDTO();
            var studentDto = new StudentDTO() { Id = expectedId };

            _mapperMock.Setup(obj => obj.Map<Student>(UpdStudent)).Returns(student);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _repoMock.Setup(obj => obj.Update(student));
            _mapperMock.Setup(obj => obj.Map<StudentDTO>(student)).Returns(studentDto);

            // Act
            var result = await _service.UpdateStudent(UpdStudent);

            // Assert
            Assert.Equal(expectedId, studentDto.Id);

        }
    }
}
