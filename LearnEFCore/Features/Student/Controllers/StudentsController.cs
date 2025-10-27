using LearnEFCore.Application.Interfaces;
using LearnEFCore.Features.Student.Commands;
using LearnEFCore.Features.Student.DTOs;
using LearnEFCore.Features.Student.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LearnEFCore.Features.Student.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;

        public StudentsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _dispatcher.Send(new GetStudentsQuery());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentDto = await _dispatcher.Send(new GetStudentByIdQuery { Id = id });
            return studentDto == null ? NotFound() : Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _dispatcher.Send<CreateStudentCommand, int>(new CreateStudentCommand { StudentDto = dto });
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _dispatcher.Send(new UpdateStudentCommand { Id = id, StudentDto = dto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dispatcher.Send(new DeleteStudentCommand { Id = id });
            return NoContent();
        }
    }
}