using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.DTO.StudentDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;
using SoftServeTestTask_BLL.Services.Interfaces.StudentServices;

namespace SoftServeTestTask_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var response = await _studentService.GetStudentById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDTO newStudent)
        {
            if (newStudent is null)
            {
                return BadRequest();
            }

            var response = await _studentService.CreateStudent(newStudent);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }

            var isDeletedSuccessfully = await _studentService.DeleteStudents(Id);
            return isDeletedSuccessfully ? Ok() : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentDTO updateStudent)
        {
            if (updateStudent is null)
            {
                return BadRequest();
            }

            var response = await _studentService.UpdateStudent(updateStudent);

            return Ok(response);
        }
    }
}
