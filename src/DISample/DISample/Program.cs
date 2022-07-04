// See https://aka.ms/new-console-template for more information


using DISample;

var x = new Injector();
//test string type
x.Singleton("salam");
Console.WriteLine(x.Get<string>());
var t =x.Singleton("salamw");
Console.WriteLine(x.Get<string>());
//test integer type
x.Transient(Injector.WriteResult);
Console.WriteLine(x.Get<int>());
x.Transient(Injector.WriteResult);
Console.WriteLine(x.Get<int>());