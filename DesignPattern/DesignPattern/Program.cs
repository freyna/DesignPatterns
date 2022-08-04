// See https://aka.ms/new-console-template for more information
using DesignPattern._01Singleton;
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;

var log = Log.Instance;

await log.Save("a");
await log.Save("b");

using (var context = new DesignPatternContext())
{
    var repository = new Repository<Beer>(context);

    var newBeer = new Beer
    {
        Name = "Otra cerveza 2",
        Style = "Natural"
    };

    repository.Add(newBeer);

    repository.Save();

    var beers = repository.GetAll();

    foreach(var beer in beers)
    {
        Console.WriteLine(beer.Name);
    }
 }


