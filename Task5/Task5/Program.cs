using Task5.Data;
using Task5.Models;

var context = new AppDbContext();

void Create(string name)
{
    if(name != null)
    {
        Subject subject = new()
        {
            Name = name
        };
        context.Subjects.Add(subject);
        context.SaveChanges();
        Console.WriteLine("Subject created successfully");
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
}
void Update(int id, string newName)
{
    var subject = context.Subjects.First(x => x.Id == id);
    if(subject != null)
    {
        subject.Name = newName;
        context.SaveChanges();
        Console.WriteLine("Subject updated successfully");
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
}
void Delete(int id)
{
    var subject = context.Subjects.First(context => context.Id == id);
    if(subject != null)
    {
        context.Subjects.Remove(subject);
        context.SaveChanges();
        Console.WriteLine("Subject deleted successfully");
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
}
void GetById(int id)
{
    var subject = context.Subjects.First(context => context.Id == id);
    if(subject != null)
    {
        Console.WriteLine($"Subject id: {subject.Id}, Subject name: {subject.Name}");
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
}

Console.WriteLine("1.Create subject \n2.Update subject by ID\n3.Delete subject by ID\n4.Read subject by ID\n5.Exit");
var key = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(key);
if(key == 1)
{
    Console.WriteLine("Enter name for new subject");
    var name = Console.ReadLine();
    Create(name);
}
else if(key == 2)
{
    Console.WriteLine("Enter the id of subject");
    var id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter new name for the subject");
    var newName = Console.ReadLine();
    Update(id,newName);
}
else if (key == 3)
{
    Console.WriteLine("Enter the id of subject");
    var id = Convert.ToInt32(Console.ReadLine());
    Delete(id);
}
else if(key == 4)
{
    var subjects = context.Subjects.ToList();
    if(subjects != null)
    {
        foreach (var subject in subjects)
        {
            Console.WriteLine($"Subject id: {subject.Id}, Subject name: {subject.Name}");
        }
    }
    else
    {
        Console.WriteLine("List is empty");
    }
}
else if (key == 5)
{
    Environment.Exit(0);
}
else
{
    Console.WriteLine("Wrong input");
}