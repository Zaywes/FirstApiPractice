var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<StudentService>();

// Add controller support
builder.Services.AddControllers();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//lebron james

// HTTPS redirection
app.UseHttpsRedirection();

// Map controllers
app.MapControllers();

app.Run();
