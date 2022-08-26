// See https://aka.ms/new-console-template for more information
using DesignPattern._01Singleton;
using DesignPattern.Models;
using DesignPattern.RepositoryPattern;
using DesignPattern.Strategy;
using DesignPattern.UnitOfWork;

var context = new ContextStrategy(new AutoStrategy());

context.run();

// Ahora cambiamos el tipo de contexto
context.Strategy = new MotoStrategy();
context.run();

// Nuevamente cambiamos el tipo de contexto para manejar otro comportamiento
context.Strategy = new BicicletaStrategy();
context.run();