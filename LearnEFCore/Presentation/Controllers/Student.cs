using LearnEFCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LearnEFCore.Presentation.Controllers;

[ApiController]
[Route("student")]
public class Student : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    public Student(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    // Get a student by ID

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        {
        try
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            return Ok(student);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}