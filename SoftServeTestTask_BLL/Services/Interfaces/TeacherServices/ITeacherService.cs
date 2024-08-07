using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.Services.Interfaces.TeacherServices
{
    public interface ITeacherService
    {
        Task<TeacherDTO> CreateTeacher(CreateTeacherDTO newTeacher);
        Task<IEnumerable<TeacherDTO>> GetAllTeachers();
        Task<bool> DeleteTeacher(int Id);
        Task<TeacherDTO> UpdateTeacher(UpdateTeacherDTO updateTeacher);
        Task<TeacherDTO> GetTeacherById(int Id);
    }
}
