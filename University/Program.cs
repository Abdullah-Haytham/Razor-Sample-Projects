using EdgeDB;
using Microsoft.AspNetCore.Mvc;
using University.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddEdgeDB(EdgeDBConnection.FromInstanceName("university"), config =>
{
    config.SchemaNamingStrategy = INamingStrategy.SnakeCaseNamingStrategy;
});

var app = builder.Build();

app.MapGet("/student-info", async (string studentId, EdgeDBClient client) =>
{
    if (!string.IsNullOrWhiteSpace(studentId))
    {
        string query = @"
            SELECT Student {
                student_id,
                name,
                age,
                courses: {
                    name,
                    code,
                    credit,
                    department: {
                        name,
                        code
                    },
                    students
                },
                department: {
                    name,
                    code,
                    students,
                }
            }
            FILTER .student_id = <str>$studentId";

        var student = await client.QuerySingleAsync<StudentModel>(query, new Dictionary<string, Object?> 
        {
            {"studentId", studentId},
        });
        if(student is not null)
        {
            string html = $"""
                <div>Name: {student.Name}</div>
                <div>Age: {student.Age}</div>
                <div>Department: {student.Department.Name}</div>
                <a href="/EditStudent?studentId={studentId}"></a>
            """;
            return Results.Content(html);
        }
        return Results.Content("<h1>Invalid Student Id</h1>");
    }
    return Results.Content("<h1>Please Provide a student id</h1>");
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
