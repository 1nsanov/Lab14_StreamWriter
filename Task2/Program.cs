class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var rnd = new Random();
        Console.WriteLine("Input count of numbers");
        var n = int.Parse(Console.ReadLine());
        using (var writer = new StreamWriter("Main_2.txt"))
        {
            for (var i = 0; i < n; i++)
                writer.WriteLine(rnd.Next(5, 100));
        }

        var result = File.ReadAllLines("Main_2.txt");


        var listNumbers = new List<int>();
        foreach (var item in result)
        {
            if (int.TryParse(item?.Trim(), out var number))
                listNumbers.Add(number);
        }
        var avg = listNumbers.Average();
        Console.WriteLine($"avg = {avg}");
        var newList = new List<int>();
        foreach (var item in listNumbers)
        {
            if (item > avg)
                newList.Add(0);
            else
                newList.Add(item);
        }

        using (var writer = new StreamWriter("NewList_2.txt"))
        {
            foreach (var item in newList)
                writer.WriteLine(item);
        }

        Console.WriteLine("All");
        Console.WriteLine(File.ReadAllText("Main_2.txt"));
        Console.WriteLine("New List");
        Console.WriteLine(File.ReadAllText("NewList_2.txt"));
    }
}
