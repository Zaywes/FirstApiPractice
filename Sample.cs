// using System.Reflection.Metadata.Ecma335;
// using Microsoft.AspNetCore.SignalR;
// using Microsoft.AspNetCore.Mvc;

// public class Student
// {
// public int Id {get; set;}
// public string Name {get; set;}
// public int Age {get; set;}
// }

// public class CreateStudentDto
// {
//     public string Name {get; set;}
//     public int Age{get; set;}
// }

// public class UpdateStudentDto
// {
//     public string Name {get; set;}
//     public int Age {get; set;}
// }


// public class StudentService
// {
//     private static List<Student> _students = new();
//     private static int _nextId = 1;

//     public List<Student> GetAll()
//     {
//         return _students;
//     }

//     public Student GetById(int id)
//     {
//         return _students.FirstOrDefault(s => s.Id == id);
//     }

//     public Student Create(CreateStudentDto dto)
//     {
//         var student = new Student
//         {
//             Id = _nextId++,
//             Name = dto.Name,
//             Age = dto.Age
//         };

//         _students.Add(student);
//         return student;
//     }

//     public bool Update(int id, UpdateStudentDto dto)
//     {
//         var student = GetById(id);
//         if (student == null) return false;

//         student.Name = dto.Name;
//         student.Age = dto.Age;
//         return true;
//     }

//     public bool Delete(int id)
//     {
//         var student = GetById(id);
//         if (student == null) return false;

//         _students.Remove(student);
//         return true;
//     }
// }


// [ApiController]
// [Route("api/students")]
// public class StudentsController : ControllerBase
// {
//     private readonly StudentService _service = new();

//     [HttpGet]
//     public IActionResult GetAll()
//     {
//         return Ok(_service.GetAll());
//     }

//     [HttpGet("{id}")]
//     public IActionResult GetById(int id)
//     {
//         var student = _service.GetById(id);
//         if (student == null)
//             return NotFound();

//         return Ok(student);
//     }

//     [HttpPost]
//     public IActionResult Create(CreateStudentDto dto)
//     {
//         var student = _service.Create(dto);
//         return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
//     }

//     [HttpPut("{id}")]
//     public IActionResult Update(int id, UpdateStudentDto dto)
//     {
//         var updated = _service.Update(id, dto);
//         if (!updated)
//             return NotFound();

//         return NoContent();
//     }
  

//     [HttpDelete("{id}")]
//     public IActionResult Delete(int id)
//     {
//         var deleted = _service.Delete(id);
//         if (!deleted)
//             return NotFound();

//         return NoContent();
//     }
// }
// namespace FirstApi.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class StudentController : ControllerBase
//     {
//         private readonly StudentService _service;

//         public StudentController(StudentService service)
//         {
//             _service = service;
//         }

//         [HttpPost]
//         public IActionResult Create(CreateStudentDto dto)
//         {
//             // VALIDATION (request correctness)
//             if (string.IsNullOrWhiteSpace(dto.Name))
//                 return BadRequest("Name is required");

//             if (dto.Age <= 0)
//                 return BadRequest("Age must be greater than 0");

//             // BUSINESS LOGIC
//             var student = _service.Create(dto);

//             return CreatedAtAction(
//                 nameof(GetById),
//                 new { id = student.Id },
//                 student
//             );
//         }

//         [HttpGet("{id}")]
//         public IActionResult GetById(int id)
//         {
//             var student = _service.GetById(id);
//             if (student == null)
//                 return NotFound();

//             return Ok(student);
//         }
//     }
// }

// public Student Create(CreateStudentDto dto)
// {
//     if (dto.Age < 18)
//         throw new InvalidOperationException("Student must be at least 18");

//     return new Student
//     {
//         Id = _nextId++,
//         Name = dto.Name,
//         Age = dto.Age
//     };
// }


