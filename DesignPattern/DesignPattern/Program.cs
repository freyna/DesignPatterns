// See https://aka.ms/new-console-template for more information
using DesignPattern._01Singleton;

var log = Log.Instance;

await log.Save("a");
await log.Save("b");