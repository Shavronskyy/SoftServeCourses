using AutoMapper;
using Microsoft.Extensions.Logging;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.StudentServices;
using SoftServeTestTask_DAL.Entities;
using SoftServeTestTask_DAL.Repositories.Interfaces.StudentRep;

namespace SoftServeTestTask_BLL.Services.Realizations.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IMapper mapper, IStudentRepository studentRepository, ILogger<StudentService> logger)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _logger = logger;
        }

        public async Task<StudentDTO> CreateStudent(CreateStudentDTO newStudent)
        {
            if (newStudent == null)
            {
                var message = "new student is null";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var student = _mapper.Map<Student>(newStudent);

            student = await _studentRepository.CreateAsync(student);
            await _studentRepository.SaveChangesAsync();

            var response = _mapper.Map<StudentDTO>(student);

            return response;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<StudentDTO>>(students);
        }

        public async Task<bool> DeleteStudents(int Id)
        {
            if(Id <= 0)
            {
                var message = "id is <= than zero";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var student = await _studentRepository.GetByIdAsync(Id);
            if (student is null)
            {
                var message = "Student Not Found";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();

            return true;
        }

        public async Task<StudentDTO> UpdateStudent(UpdateStudentDTO updateStudent)
        {
            if (updateStudent is null)
            {
                var message = "updateStudent is null!";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var student = _mapper.Map<Student>(updateStudent);

            _studentRepository.Update(student);
            await _studentRepository.SaveChangesAsync();

            return _mapper.Map<StudentDTO>(student);
        }

        public async Task<StudentDTO> GetStudentById(int Id)
        {
            if (Id <= 0)
            {
                var message = "id is <= than zero";
                _logger.LogError(message);
                throw new ArgumentNullException(message);
            }

            var student = await _studentRepository.GetByIdAsync(Id);

            return _mapper.Map<StudentDTO>(student);
        }
    }
}
