// See https://aka.ms/new-console-template for more information


using DISample;

var x = new Injector();
x.Singleton("salam");
Console.WriteLine(x.Get<string>());
x.Singleton("salamw");
x.Transition(Injector.WriteResult, 4);
Console.WriteLine(x.Get<int>());
x.Transition(Injector.WriteResult, 6);
Console.WriteLine(x.Get<int>());
Console.WriteLine(x.Get<string>());
Console.WriteLine("Hello, World!");