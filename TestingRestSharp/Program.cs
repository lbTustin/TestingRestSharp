// See https://aka.ms/new-console-template for more information
using TestingRestSharp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var result = await ApiHTTPClient.PostApi();
        var response = await result.Content.ReadAsStringAsync();
        Console.WriteLine("Hello, World!");
    }
}