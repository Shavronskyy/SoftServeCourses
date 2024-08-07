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
    public class CreateStudentStudentService
    {
        private readonly Mock<IStudentRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IStudentService _service;
        private readonly ILogger<StudentService> _logger;

        public CreateStudentStudentService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<IStudentRepository>();
            _service = new StudentService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task CreateStudent_ReturnsError_WhenInputNull()
        {
            // Arrange

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateStudent(null!));
        }

        [Fact]
        public async Task CreateStudent_ReturnsError_WhenMapperReturnNull()
        {
            // Arrange
            var newStudent = new CreateStudentDTO();
            var studentDto = new StudentDTO();

            _mapperMock.Setup(obj => obj.Map<Student>(studentDto)).Returns((Student)null!);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateStudent(newStudent));
        }

        [Fact]
        public async Task CreateStudent_ReturnsError_WhenSaveChangesFailed()
        {
            // Arrange
            var newStudent = new CreateStudentDTO();
            var studentDto = new StudentDTO();
            var student = new Student();

            _mapperMock.Setup(obj => obj.Map<Student>(newStudent)).Returns(student);
            _repoMock.Setup(obj => obj.CreateAsync(student));
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateStudent(newStudent));
        }

        [Fact]
        public async Task CreateStudent_ReturnsSuccess_WhenInputCorrectData()
        {
            // Arrange
            var expectedName = "string";
            var newStudent = new CreateStudentDTO();
            var studentDto = new StudentDTO() { Name = expectedName };
            var student = new Student();

            _mapperMock.Setup(obj => obj.Map<Student>(newStudent)).Returns(student);
            _repoMock.Setup(obj => obj.CreateAsync(student)).ReturnsAsync(student);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _mapperMock.Setup(obj => obj.Map<StudentDTO>(student)).Returns(studentDto);

            // Act
            var result = await _service.CreateStudent(newStudent);

            // Assert 
            Assert.Equal(expectedName, result.Name);
        }
    }
}
