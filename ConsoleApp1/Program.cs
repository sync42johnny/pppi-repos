using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        //Example using System.Linq to filter a list of numbers:
        Console.WriteLine("System.Linq");
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var evenNumbers = numbers.Where(n => n % 2 == 0);

        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }


        //Example using System.Diagnostics to measure the time it takes to execute a method:
        Console.WriteLine("\nSystem.Diagnostics");
        Stopwatch stopwatch = Stopwatch.StartNew();
        // Call the method to measure here
        MyMethod("method", 'd');
        stopwatch.Stop();

        Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);


        //Example using System.IO.File to read a file:
        Console.WriteLine("\nSystem.IO.File");
        string filePath = @"C:\Users\IVAN\Documents\myfile.txt";

        string content = File.ReadAllText(filePath);
        Console.WriteLine(content);


        //Example using System.Text.RegularExpressions to match a pattern in a string:
        Console.WriteLine("\nSystem.Text.RegularExpressions");
        string input = "The quick brown fox jumps over the lazy dog.";
        string pattern = "fox";

        bool isMatch = Regex.IsMatch(input, pattern);
        Console.WriteLine(isMatch ? "Match found." : "Match not found.");

        //Working with the System.Collections.Generic API to use a dictionary:
        Console.WriteLine("\nSystem.Collections.Generic");
        var dictionary = new Dictionary<string, string>();
        dictionary.Add("name", "John");
        dictionary.Add("age", "25");

        Console.WriteLine("Name: {0}", dictionary["name"]);
        Console.WriteLine("Age: {0}", dictionary["age"]);
    }

    static void MyMethod(string source, char toFind)
    {
        // Code to measure here
        int count = 0;
        foreach (var ch in source)
        {
            if (ch == toFind)
                count++;
        }
        Console.WriteLine(count);
    }
}