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
    public class GetTeacherByIdTeacherService
    {
        private readonly Mock<ITeacherRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ITeacherService _service;
        private readonly ILogger<TeacherService> _logger;

        public GetTeacherByIdTeacherService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<ITeacherRepository>();
            _service = new TeacherService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task GetTeacherById_ReturnsError_WhenReturnsNull()
        {
            // Arrange
            _repoMock.Setup(obj => obj.GetByIdAsync(default)).ReturnsAsync((Teacher)null!);
            var searchedId = 1;

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetTeacherById(searchedId));
        }

        [Fact]
        public async Task GetTeacherById_ReturnsError_WhenInputZeroOrLess()
        {
            // Arrange
            var searchedId = -1;

            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.GetTeacherById(searchedId));
        }

        [Fact]
        public async Task GetTeacherById_ReturnCorrectStudent_WhenInputValidData()
        {
            // Arrange
            var teacher = new Teacher()
            {
                Id = 1
            };
            var teacherDto = new TeacherDTO()
            {
                Id = 1,
            };
            var searchedId = 1;
            _repoMock.Setup(obj => obj.GetByIdAsync(searchedId)).ReturnsAsync(teacher);
            _mapperMock.Setup(obj => obj.Map<TeacherDTO>(teacher)).Returns(teacherDto);

            // Assert
            var result = await _service.GetTeacherById(searchedId);

            // Act
            Assert.Equal(searchedId, result.Id);
        }
    }
}
