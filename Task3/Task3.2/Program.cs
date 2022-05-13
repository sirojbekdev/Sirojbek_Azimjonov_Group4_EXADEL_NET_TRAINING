
using System.Text.Json;
using Task3._2;


string cityPath = File.ReadAllText(@".\Files\city.json");
var cities = System.Text.Json.JsonSerializer.Deserialize<List<Cities>>(cityPath);

var inhabitantPath = File.ReadAllText(@".\Files\inhabitant.json");
var inhabitants = JsonSerializer.Deserialize<List<Inhabitant>>(inhabitantPath);

var joinedTable = (from inhab in inhabitants
                  join c in cities on inhab.city equals  c.city
                  select new
                  {
                      inhab.name,
                      inhab.surname,
                      inhab.age,
                      inhab.city,
                      cityPopulation = c.population
                  }).ToList().Where(x=>x.cityPopulation>50000);

foreach (var inhabitant in joinedTable)
{
    if (inhabitant.age > 15 && inhabitant.age<65)
    {
        Console.WriteLine($"{inhabitant.name} {inhabitant.surname} is employable");
    }
    else
    {
        Console.WriteLine($"{inhabitant.name} {inhabitant.surname} is not employable");
    }
};
//Console.WriteLine(items);
//Console.WriteLine(cities);

//foreach (var c in cities)
//{
//    Console.WriteLine("city: "+c.City);
//    Console.WriteLine("pop: "+c.population);
//}
//foreach(var inhabitant in inhabitants)
//{
//    Console.WriteLine("Name: " + inhabitant.name);
//    Console.WriteLine("pop: " + inhabitant.surname);
//    Console.WriteLine("pop: " + inhabitant.age);
//    Console.WriteLine("city: " + inhabitant.city);
//}