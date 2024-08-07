using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_BLL.Services.Interfaces.StudentServices;
using SoftServeTestTask_BLL.Services.Interfaces.TeacherServices;
using SoftServeTestTask_BLL.Services.Realizations.CourseServices;
using SoftServeTestTask_BLL.Services.Realizations.StudentServices;
using SoftServeTestTask_BLL.Services.Realizations.TeacherServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.CourseRep;
using SoftServeTestTask_DAL.Repositories.Interfaces.StudentRep;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;
using SoftServeTestTask_DAL.Repositories.Realizations.TeacherRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_Tests.ServicesTests.TeacherTests
{
    public class CreateTeacherTeacherService
    {
        private readonly Mock<ITeacherRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ITeacherService _service;
        private readonly ILogger<TeacherService> _logger;

        public CreateTeacherTeacherService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<ITeacherRepository>();
            _service = new TeacherService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task CreateTeacher_ReturnsError_WhenInputNull()
        {
            // Arrange

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateTeacher(null!));
        }

        [Fact]
        public async Task CreateTeacher_ReturnsError_WhenMapperReturnNull()
        {
            // Arrange
            var newTeacher = new CreateTeacherDTO();
            var teacherDto = new TeacherDTO();

            _mapperMock.Setup(obj => obj.Map<Teacher>(teacherDto)).Returns((Teacher)null!);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateTeacher(newTeacher));
        }

        [Fact]
        public async Task CreateStudent_ReturnsError_WhenSaveChangesFailed()
        {
            // Arrange
            var newTeacher = new CreateTeacherDTO();
            var teacherDto = new TeacherDTO();
            var teacher = new Teacher();

            _mapperMock.Setup(obj => obj.Map<Teacher>(newTeacher)).Returns(teacher);
            _repoMock.Setup(obj => obj.CreateAsync(teacher));
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.CreateTeacher(newTeacher));
        }

        [Fact]
        public async Task CreateStudent_ReturnsSuccess_WhenInputCorrectData()
        {
            // Arrange
            var expectedName = "string";
            var newTeacher = new CreateTeacherDTO();
            var teacherDto = new TeacherDTO() { Name = expectedName };
            var teacher = new Teacher();

            _mapperMock.Setup(obj => obj.Map<Teacher>(newTeacher)).Returns(teacher);
            _repoMock.Setup(obj => obj.CreateAsync(teacher)).ReturnsAsync(teacher);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _mapperMock.Setup(obj => obj.Map<TeacherDTO>(teacher)).Returns(teacherDto);

            // Act
            var result = await _service.CreateTeacher(newTeacher);

            // Assert 
            Assert.Equal(expectedName, result.Name);
        }
    }
}
