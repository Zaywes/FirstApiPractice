using Microsoft.AspNetCore.Mvc;

public class CreateStudentDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
}