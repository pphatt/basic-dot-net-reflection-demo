public interface ILevel1 { }
public interface ILevel2 : ILevel1 { }
public interface ILevel3 : ILevel2 { }
public interface ILevel4 : ILevel3 { }
public interface ILevel5 : ILevel4 { }
public interface ILevel6 : ILevel5 { }

public class MyClass : ILevel6 { }

internal class Program
{
    private static void Main()
    {
        IEnumerable<Type> allInterfaces = typeof(MyClass).GetInterfaces();

        Console.WriteLine("All interfaces implemented by MyClass:");

        foreach (var i in allInterfaces)
        {
            Console.WriteLine(i.Name);
        }

        IEnumerable<Type> inheritedInterfaces = allInterfaces.SelectMany(i => i.GetInterfaces());

        Console.WriteLine("\nInherited interfaces from the first level:");

        foreach (var i in inheritedInterfaces)
        {
            Console.WriteLine(i.Name);
        }

        Type? directInterface = allInterfaces.Except(inheritedInterfaces).FirstOrDefault();

        Console.WriteLine("\nDirect interface of MyClass:");
        Console.WriteLine(directInterface?.Name ?? "None");
    }
}
