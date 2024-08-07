using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_BLL.Services.Interfaces.StudentServices;
using SoftServeTestTask_BLL.Services.Realizations.CourseServices;
using SoftServeTestTask_BLL.Services.Realizations.StudentServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;
using SoftServeTestTask_DAL.Repositories.Interfaces.StudentRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_Tests.ServicesTests.StudentTests
{
    public class GetStudentByIdStudentsServiceTests
    {
        private readonly Mock<IStudentRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IStudentService _service;
        private readonly ILogger<StudentService> _logger;

        public GetStudentByIdStudentsServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<IStudentRepository>();
            _service = new StudentService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task GetStudentById_ReturnsError_WhenReturnsNull()
        {
            // Arrange
            _repoMock.Setup(obj => obj.GetByIdAsync(default)).ReturnsAsync((Student)null!);
            var searchedId = 1;

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetStudentById(searchedId));
        }

        [Fact]
        public async Task GetStudentById_ReturnsError_WhenInputZeroOrLess()
        {
            // Arrange
            var searchedId = -1;

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetStudentById(searchedId));
        }

        [Fact]
        public async Task GetStudentById_ReturnCorrectStudent_WhenInputValidData()
        {
            // Arrange
            var student = new Student()
            {
                Id = 1
            };
            var studentDto = new StudentDTO()
            {
                Id = 1,
            };
            var searchedId = 1;
            _repoMock.Setup(obj => obj.GetByIdAsync(searchedId)).ReturnsAsync(student);
            _mapperMock.Setup(obj => obj.Map<StudentDTO>(student)).Returns(studentDto);

            // Assert
            var result = await _service.GetStudentById(searchedId);

            // Act
            Assert.Equal(searchedId, result.Id);
        }
    }
}
