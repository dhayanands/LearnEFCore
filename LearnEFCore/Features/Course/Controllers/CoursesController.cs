using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Course.Commands;
using LearnEFCore.Features.Course.DTOs;
using LearnEFCore.Features.Course.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LearnEFCore.Features.Course.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public CoursesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = await _dispatcher.Send(new GetCoursesQuery());
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var courseDto = await _dispatcher.Send(new GetCourseByIdQuery { Id = id });
            return courseDto == null ? NotFound() : Ok(courseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _dispatcher.Send<CreateCourseCommand, int>(new CreateCourseCommand { CourseDto = dto });
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }
    }
}