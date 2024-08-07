using AutoMapper;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using SoftServeTestTask_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServeTestTask_BLL.Mapping.Teachers
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            CreateMap<TeacherDTO, CreateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
        }
    }
}
