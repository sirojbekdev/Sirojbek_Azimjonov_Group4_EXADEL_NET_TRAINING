using Task7.Data;
using Task7.Models;

AppDbContext dbContext = new();

List<Subject> subjects = dbContext.Subjects.ToList();

foreach(Subject subject in subjects)
{
    Console.WriteLine(subject.Name);
}