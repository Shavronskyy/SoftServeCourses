using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.DTO.TeacherDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.StudentServices;
using SoftServeTestTask_BLL.Services.Interfaces.TeacherServices;

namespace SoftServeTestTask_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _teacherService.GetAllTeachers());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var response = await _teacherService.GetTeacherById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeacherDTO newTeacher)
        {
            if (newTeacher is null)
            {
                return BadRequest();
            }

            var response = await _teacherService.CreateTeacher(newTeacher);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }

            var isDeletedSuccessfully = await _teacherService.DeleteTeacher(Id);
            return isDeletedSuccessfully ? Ok() : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherDTO updateTeacher)
        {
            if (updateTeacher is null)
            {
                return BadRequest();
            }

            var response = await _teacherService.UpdateTeacher(updateTeacher);

            return Ok(response);
        }
    }
}
