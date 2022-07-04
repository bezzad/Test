// See https://aka.ms/new-console-template for more information


using DISample;

var injector = new Injector();
//test string type
injector.Singleton("salam");
Console.WriteLine(injector.Get<string>());
injector.Singleton("salamw");
Console.WriteLine(injector.Get<string>());
//test integer type
injector.Transient(Injector.WriteResult);
Console.WriteLine(injector.Get<int>());
injector.Transient(Injector.WriteResult);
Console.WriteLine(injector.Get<int>());