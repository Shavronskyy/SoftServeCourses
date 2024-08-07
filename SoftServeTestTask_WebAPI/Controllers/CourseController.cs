using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftServeTestTask_BLL.DTO.CourseDTOs;
using SoftServeTestTask_BLL.Services.Interfaces.CourseServices;

namespace SoftServeTestTask_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseService.GetAllCourses());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var response = await _courseService.GetCourseById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDTO newCourse)
        {
            if (newCourse is null)
            {
                return BadRequest();
            }

            var response = await _courseService.CreateCourse(newCourse);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }

            var isDeletedSuccessfully = await _courseService.DeleteCourse(Id);
            return isDeletedSuccessfully ? Ok() : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseDTO newCourse)
        {
            if(newCourse is null)
            {
                return BadRequest();
            }

            var response = await _courseService.UpdateCourse(newCourse);

            return Ok(response);
        }
    }
}
