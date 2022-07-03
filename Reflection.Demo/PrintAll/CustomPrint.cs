using System;

namespace PrintAll
{

  public class CustomPrint
  {
    private string name;

    public string Name => name;

    public void Print()
    {
      Console.WriteLine("Printing from Print");
    }

    public void Print(string name)
    {
      Console.WriteLine($"Name passed: {name}");
    }

    public string GetName()
    {
      return name;
    }

    public void PrintName()
    {
      Console.WriteLine($"Name set as {name}");
    }

    private void PrintPrivate()
    {
      Console.WriteLine("Printing from private");
    }

    public static string StaticName => "Static property name";
  }
}