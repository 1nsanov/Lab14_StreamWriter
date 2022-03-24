class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var rnd = new Random();
        Console.WriteLine("Input count of numbers");
        var n = int.Parse(Console.ReadLine());
        using (var writer = new StreamWriter("Main.txt"))
        {
            for (var i = 0; i < n; i++)
                writer.WriteLine(rnd.Next(5, 100));
        }

        var result = File.ReadAllLines("Main.txt");
        CreateTxt(result);

        Console.WriteLine("All");
        Console.WriteLine(File.ReadAllText("Main.txt"));
        Console.WriteLine("First List");
        Console.WriteLine(File.ReadAllText("FirstFile.txt"));
        Console.WriteLine("Second List");
        Console.WriteLine(File.ReadAllText("SecondFile.txt"));
    }

    private static void CreateTxt(string[] result)
    {
        var fisrtList = new List<int>();
        foreach (var item in result)
        {
            if (int.TryParse(item?.Trim(), out var number))
                if (number % 5 == 0) fisrtList.Add(number);
        }
        double avgFisrtList = 0;
        if (fisrtList.Count > 0)
            avgFisrtList = fisrtList.Average();
        using (var writer = new StreamWriter("FirstFile.txt"))
        {
            foreach (var item in fisrtList)
                writer.WriteLine(item);
            writer.WriteLine($"Avg = {avgFisrtList}");
        }


        var secondList = new List<int>();
        foreach (var item in result)
        {
            if (int.TryParse(item?.Trim(), out var number))
                if (number % 5 != 0) secondList.Add(number);
        }
        double avgSecondList = 0;
        if (secondList.Count > 0)
            avgSecondList = secondList.Average();
        using (var writer = new StreamWriter("SecondFile.txt"))
        {
            foreach (var item in secondList)
                writer.WriteLine(item);
            writer.WriteLine($"Avg = {avgSecondList}");
        }
    }
}
