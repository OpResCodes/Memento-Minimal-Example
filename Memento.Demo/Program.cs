using Memento;

internal class Program
{
    private static void Main(string[] args)
    {
        DataClass line = new DataClass();
        Console.WriteLine(line);
        int n = line.ToString().Length;
        for (int i = 0; i < n; i++)
        {
            Console.Write("-");
            Thread.Sleep(10);
        }
        Console.WriteLine();
        Console.WriteLine("Storing checkpoint.");
        line.StoreCheckPoint();
        Console.WriteLine("Modifying line.");
        line.RemoveLastPoint();
        Console.WriteLine(line);
        Console.WriteLine("Modifying line.");
        line.RemoveLastPoint();
        Console.WriteLine(line);
        Console.WriteLine("Modifying line.");
        line.Add(500, -15);
        Console.WriteLine(line);
        Console.WriteLine("Restoring original checkpoint");
        line.RestoreLastCheckPoint();
        Console.WriteLine(line);

        for (int i = 0; i < n; i++)
        {
            Console.Write("-");
            Thread.Sleep(10);
        }
        Console.WriteLine();
        Console.WriteLine("Hit key to exit.");
        Console.ReadKey();

    }
}