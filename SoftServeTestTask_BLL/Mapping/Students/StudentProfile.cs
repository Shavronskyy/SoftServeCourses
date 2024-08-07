using AutoMapper;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.Mapping.Students
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<UpdateStudentDTO, Student>().ReverseMap();
            
        }
    }
}
