using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.TeacherServices;
using SoftServeTestTask_BLL.Services.Realizations.TeacherServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_Tests.ServicesTests.TeacherTests
{
    public class GetAllTeachersTeacherService
    {
        private readonly Mock<ITeacherRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ITeacherService _service;
        private readonly ILogger<TeacherService> _logger;

        public GetAllTeachersTeacherService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<ITeacherRepository>();
            _service = new TeacherService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task GetAllTeachers_ReturnsSuccess()
        {
            // Arrange
            List<Teacher> teacher = new();
            List<TeacherDTO> teacherDto = new();
            _mapperMock.Setup(obj => obj.Map<IEnumerable<TeacherDTO>>(teacher)).Returns(teacherDto);
            _repoMock.Setup(obj => obj.GetAllAsync()).ReturnsAsync(new List<Teacher>());
            // Act
            var result = _service.GetAllTeachers();

            // Assert
            Assert.NotNull(result);
        }
    }
}
