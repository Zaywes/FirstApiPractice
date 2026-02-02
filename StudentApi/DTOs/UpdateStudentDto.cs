using Microsoft.AspNetCore.Mvc;

public class UpdateStudentDto
{
    public required string Name { get; set; }
    public int Age { get; set; }
}