// See https://aka.ms/new-console-template for more information
using WebApiClientConsole;
Console.WriteLine("API CLIENT!");
EmployeeAPIClient.DeleteEmployee().Wait();
Console.ReadLine();
