using Microsoft.AspNetCore.Mvc;

public class StudentService
{
    private static List<Student> _students = new List<Student>();
    private static int _nextId = 1;

    public List<Student> GetAll()
    {
        return _students;
    }

    public Student GetById(int id)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            throw new ArgumentException("Student not Found");

        return student;
    }

    public Student Create(CreateStudentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required");

        if (dto.Age < 0)
            throw new ArgumentException("Age cannot be negative");

        if (dto.Age < 18)
            throw new InvalidOperationException("Student must be at least 18");

        if (_students.Any(s => s.Name == dto.Name))
            throw new InvalidOperationException("Student already exists");

        var student = new Student
        {
            Id = _nextId++,
            Name = dto.Name,
            Age = dto.Age,
        };

        _students.Add(student);
        return student;
    }

    public Student Update(int id, UpdateStudentDto dto)
    {
        var student = _students.FirstOrDefault(s => s.Id == id);
        if (student == null)
            throw new KeyNotFoundException("Student not found");

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required");
        if (dto.Age < 0)
            throw new ArgumentException("Age cannot be negative");

        if (dto.Age < 18)
            throw new InvalidOperationException("Student must be 18 or older");

        if (_students.Any(s => s.Name == dto.Name && s.Id != id))
            throw new InvalidOperationException("Another student with this name already exists");

        student.Name = dto.Name;
        student.Age = dto.Age;

        return student;
    }

    public Student Delete(int id)
    {
        var student = GetById(id);
        _students.Remove(student);
        return student;
    }
}
