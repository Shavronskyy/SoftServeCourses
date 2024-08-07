using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.TeacherServices;
using SoftServeTestTask_BLL.Services.Realizations.TeacherServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;

namespace SoftServeTestTask_Tests.ServicesTests.TeacherTests
{
    public class UpdateTeacherTeacherService
    {
        private readonly Mock<ITeacherRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ITeacherService _service;
        private readonly ILogger<TeacherService> _logger;

        public UpdateTeacherTeacherService()
        {
            _mapperMock = new Mock<IMapper>();
            _repoMock = new Mock<ITeacherRepository>();
            _service = new TeacherService(_mapperMock.Object, _repoMock.Object, _logger);
        }

        [Fact]
        public async Task UpdateTeacher_ReturnsError_WhenSaveFailed()
        {
            // Arrange
            var teacher = new Teacher();
            var updTeacher = new UpdateTeacherDTO();
            _mapperMock.Setup(obj => obj.Map<Teacher>(updTeacher)).Returns(teacher);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(0);
            _repoMock.Setup(obj => obj.Update(teacher));
            // Assert & Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _service.UpdateTeacher(updTeacher));
        }

        [Fact]
        public async Task UpdateTeacher_ReturnsSuccess_WhenSaveSuccess()
        {
            // Arrange
            var expectedId = 2;
            var teacher = new Teacher();
            var updTeacher = new UpdateTeacherDTO();
            var teacherDto = new TeacherDTO() { Id = expectedId };

            _mapperMock.Setup(obj => obj.Map<Teacher>(updTeacher)).Returns(teacher);
            _repoMock.Setup(obj => obj.SaveChangesAsync()).ReturnsAsync(1);
            _repoMock.Setup(obj => obj.Update(teacher));
            _mapperMock.Setup(obj => obj.Map<TeacherDTO>(teacher)).Returns(teacherDto);

            // Act
            var result = await _service.UpdateTeacher(updTeacher);

            // Assert
            Assert.Equal(expectedId, teacherDto.Id);

        }
    }
}
