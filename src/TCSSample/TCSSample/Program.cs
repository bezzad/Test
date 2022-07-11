// See https://aka.ms/new-console-template for more information
using TCSSample;

Console.WriteLine(MyTaskCompletionSource.GetTaskResult(1).Result);
Console.WriteLine(MyTaskCompletionSource.GetTaskResult(100).Result);
Console.WriteLine(MyTaskCompletionSource.GetTaskResult(200).Result);
Console.WriteLine("Hello, World!");

