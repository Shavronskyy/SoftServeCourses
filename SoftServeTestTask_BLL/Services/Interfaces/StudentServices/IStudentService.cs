using SoftServeTestTask_BLL.DTO.StudentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.Services.Interfaces.StudentServices
{
    public interface IStudentService
    {
        Task<StudentDTO> CreateStudent(CreateStudentDTO newStudent);
        Task<IEnumerable<StudentDTO>> GetAllStudents();
        Task<bool> DeleteStudents(int Id);
        Task<StudentDTO> UpdateStudent(UpdateStudentDTO updateStudent);
        Task<StudentDTO> GetStudentById(int Id);
    }
}
