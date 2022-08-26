// See https://aka.ms/new-console-template for more information
using DesignPattern._01Singleton;
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
using DesignPattern.UnitOfWork;

var log = Log.Instance;

await log.Save("a");
await log.Save("b");

using (var context = new DesignPatternContext())
{
    var unitOfWork = new UnitOfWork(context);
    var repository = new Repository<Beer>(context);

    var newBeer = new Beer
    {
        Name = "Heineken",
        Style = "Natural"
    };

    repository.Add(newBeer);

    await unitOfWork.Save();

    var beers = repository.GetAll();

    foreach(var beer in beers)
    {
        Console.WriteLine(beer.Name);
    }
 }


