using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/controller")]
public class StudentController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        return NotFound();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        return Ok();
    }
}