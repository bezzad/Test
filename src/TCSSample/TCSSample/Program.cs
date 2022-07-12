// See https://aka.ms/new-console-template for more information
using TCSSample;
Console.WriteLine(await MyTaskCompletionSource.GetTaskResult(200));
Console.WriteLine(await MyTaskCompletionSource.GetTaskResult(1));
Console.WriteLine(await MyTaskCompletionSource.GetTaskResult(100));
Console.WriteLine("Hello, World!");

