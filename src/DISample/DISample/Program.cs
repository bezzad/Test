// See https://aka.ms/new-console-template for more information


using DISample;

var injector = new Injector();
//test string type
injector.Singleton("salam");
Console.WriteLine(injector.Get<string>());
injector.Singleton("salamw");
Console.WriteLine(injector.Get<string>());
injector.Singleton(new Person("ss", 1, 2));
var d = injector.Get<Person>();
injector.Singleton(new Person("ssw", 1, 2));
var de = injector.Get<Person>();