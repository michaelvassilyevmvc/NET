using System;
using System.Linq;
using System.Reflection;

namespace Reflection.Demo.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      var assembly = Assembly.LoadFile(@"C:\Project\NET\Reflection.Demo\PrintAll\bin\Debug\net5.0\PrintAll.dll");
      foreach (var type in assembly.GetTypes())
      {
        Console.WriteLine($"Type: {type.Name}");
        Console.WriteLine(new String('=', 20));
        var instance = Activator.CreateInstance(type);



        foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
          System.Console.WriteLine($"Field: {field.Name}");
          field.SetValue(instance, "Frodo");
        }
        Console.WriteLine(new String('=', 20));

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
          .Where(m => !m.IsSpecialName))
        {
          System.Console.WriteLine($"Method: {method.Name}");
          if (method.GetParameters().Length > 0)
          {
            method.Invoke(instance, new[] { "Bilbo" });
          }
          else if (method.ReturnType.Name != "Void")
          {
            var returnedValue = method.Invoke(instance, null);
            Console.WriteLine($"Returned value from method: {returnedValue}");
          }
          else
          {
            method.Invoke(instance, null);
          }
        }
        Console.WriteLine(new String('=', 20));

        foreach (var property in type.GetProperties())
        {
          Console.WriteLine($"Property: {property.Name}");
          var propertyValue = property.GetValue(instance);
          Console.WriteLine($"Property value: {propertyValue}");
        }
        Console.WriteLine(new String('=', 20));

      }

    }

  }
}
