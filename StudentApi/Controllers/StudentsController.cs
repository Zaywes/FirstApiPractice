using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentsController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _studentService.GetAll();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var student = _studentService.GetById(id);
            return Ok(student);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Create(CreateStudentDto dto)
    {
        try
        {
            var student = _studentService.Create(dto);
            return StatusCode(201, student);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "Unexpected server error");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateStudentDto dto)
    {
        try
        {
            var updatedStudent = _studentService.Update(id, dto);
            return Ok(updatedStudent);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _studentService.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}
