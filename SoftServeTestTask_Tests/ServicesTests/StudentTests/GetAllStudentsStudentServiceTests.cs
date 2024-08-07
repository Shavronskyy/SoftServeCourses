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
    public class GetAllStudentsStudentServiceTests
    {
        private readonly Mock<IStudentRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IStudentService _service;
        private readonly ILogger<StudentService> _logger;

        public GetAllStudentsStudentServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<IStudentRepository>();
            _service = new StudentService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task GetAllStudents_ReturnsSuccess()
        {
            // Arrange
            List<Student> student = new();
            List<StudentDTO> studentDto = new();
            _mapperMock.Setup(obj => obj.Map<IEnumerable<StudentDTO>>(student)).Returns(studentDto);
            _repoMock.Setup(obj => obj.GetAllAsync()).ReturnsAsync(new List<Student>());
            // Act
            var result = _service.GetAllStudents();

            // Assert
            Assert.NotNull(result);
        }
    }
}
