using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("StudentApi")]
public class StudentsController : ControllerBase
{
    private readonly StudentService _service = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _service.GetById(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(CreateStudentDto dto)
    {
        // VALIDATION (request correctness)
        if (string.IsNullOrWhiteSpace(dto.Name))
         return BadRequest("Name is required");

        if (dto.Age <= 0)
            return BadRequest("Age must be greater than 0");

        // BUSINESS LOGIC
        var student = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }


    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateStudentDto dto)
    {
        var updated = _service.Update(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _service.Delete(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
