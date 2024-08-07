using AutoMapper;
using Microsoft.Extensions.Logging;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.TeacherServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.TeacherRep;

namespace SoftServeTestTask_BLL.Services.Realizations.TeacherServices
{
    public class TeacherService : ITeacherService
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepo;
        private readonly ILogger<TeacherService> _logger;

        public TeacherService(IMapper mapper, ITeacherRepository teacherRepo, ILogger<TeacherService> logger)
        {
            _mapper = mapper;
            _teacherRepo = teacherRepo;
            _logger = logger;
        }

        public async Task<TeacherDTO> CreateTeacher(CreateTeacherDTO newTeacher)
        {
            if (newTeacher == null)
            {
                var message = "newTeacher is null";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var teacher = _mapper.Map<Teacher>(newTeacher);

            teacher = await _teacherRepo.CreateAsync(teacher);
            await _teacherRepo.SaveChangesAsync();

            var response = _mapper.Map<TeacherDTO>(teacher);

            return response;
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllTeachers()
        {
            var teachers = await _teacherRepo.GetAllAsync();

            return _mapper.Map<IEnumerable<TeacherDTO>>(teachers);
        }

        public async Task<bool> DeleteTeacher(int Id)
        {
            if(Id <= 0)
            {
                var message = "id is <= than zero";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }
            var teacher = await _teacherRepo.GetByIdAsync(Id);
            if (teacher is null)
            {
                var message = "teacher is null";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            _teacherRepo.Delete(teacher);
            await _teacherRepo.SaveChangesAsync();

            return true;
        }

        public async Task<TeacherDTO> UpdateTeacher(UpdateTeacherDTO updateTeacher)
        {
            if (updateTeacher is null)
            {
                var message = "update teacher is null";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var teacher = _mapper.Map<Teacher>(updateTeacher);

            _teacherRepo.Update(teacher);
            await _teacherRepo.SaveChangesAsync();

            return _mapper.Map<TeacherDTO>(teacher);
        }

        public async Task<TeacherDTO> GetTeacherById(int Id)
        {
            if (Id <= 0)
            {
                var message = "id is <= than zero";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var teacher = await _teacherRepo.GetByIdAsync(Id);

            return _mapper.Map<TeacherDTO>(teacher);
        }
    }
}
