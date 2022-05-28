using Task6._1.Data;
using Task6._1.Models;

var context = new AppDbContext();

async Task CreateAsync(string name)
{
    if (name != null)
    {
        Subject subject = new()
        {
            Name = name
        };
        context.Subjects.Add(subject);
        await context.SaveChangesAsync();
        Console.WriteLine("Subject created successfully");
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
    await StartAsync();
}
async Task UpdateAsync(int id, string newName)
{
    var subject = await context.Subjects.FindAsync(id);
    if (subject != null)
    {
        subject.Name = newName;
        await context.SaveChangesAsync();
        Console.WriteLine("Subject updated successfully");
    }
    else
    {
        Console.WriteLine("Wrong input or data does not exist");
    }
    await StartAsync();
}
async Task DeleteAsync(int id)
{
    var subject = await context.Subjects.FindAsync(id);
    if (subject != null)
    {
        context.Subjects.Remove(subject);
        await context.SaveChangesAsync();
        Console.WriteLine("Subject deleted successfully");
    }
    else
    {
        Console.WriteLine("Wrong input or data does not exist");
    }
    await StartAsync();
}
async Task GetByIdAsync(int id)
{
    var subject = await context.Subjects.FindAsync(id);
    if (subject != null)
    {
        Console.WriteLine($"Subject id: {subject.Id}, Subject name: {subject.Name}");
    }
    else
    {
        Console.WriteLine("Wrong input or data does not exist");
    }
    await StartAsync();
}

async Task StartAsync()
{
    Console.WriteLine("1.Create subject \n2.Update subject by ID\n3.Delete subject by ID\n4.Read subject by ID\n5.Exit");
    var key = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(key);
    if (key == 1)
    {
        Console.WriteLine("Enter name for new subject");
        var name = Console.ReadLine();
        await CreateAsync(name);
    }
    else if (key == 2)
    {
        Console.WriteLine("Enter the id of subject");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter new name for the subject");
        var newName = Console.ReadLine();
        await UpdateAsync(id, newName);
    }
    else if (key == 3)
    {
        Console.WriteLine("Enter the id of subject");
        var id = Convert.ToInt32(Console.ReadLine());
        await DeleteAsync(id);
    }
    else if (key == 4)
    {
        Console.WriteLine("Enter the id of subject");
        var id = Convert.ToInt32(Console.ReadLine());
        await GetByIdAsync(id);
    }
    else if (key == 5)
    {
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
}

await StartAsync();