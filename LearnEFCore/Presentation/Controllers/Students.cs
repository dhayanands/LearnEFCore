using LearnEFCore.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LearnEFCore.Presentation.Controllers;

[ApiController]
[Route("students")]
public class Students : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public Students(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IActionResult> Get()
    {
        try
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return Ok(students);
        }
        catch (FileNotFoundException)
        {
            return NotFound("Quotes file not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}