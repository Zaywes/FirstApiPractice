using Microsoft.AspNetCore.Mvc;

public class StudentService
{
    private static List<Student> _students;
    private static int _nextId = 1;


    public List<Student> GetAll()
    {
        return _students;
    }

    public Student? GetById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public Student Create(CreateStudentDto dto)
    {
        if (dto.Age < 18)
            throw new InvalidOperationException("Student must be at least 18");

        return new Student
        {
            Id = _nextId++,
            Name = dto.Name,
            Age = dto.Age
        };
    }


    public bool Update(int id, UpdateStudentDto dto)
    {
        var student = GetById(id);
        if (student == null) return false;

        student.Name = dto.Name;
        student.Age = dto.Age;
        return true;
    }

    public bool Delete(int id)
    {
        var student = GetById(id);
        if (student == null) return false;

        _students.Remove(student);
        return true;
    }
}
