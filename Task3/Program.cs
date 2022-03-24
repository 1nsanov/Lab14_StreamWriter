class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        var path = @"D:\Test";
        Console.WriteLine("Подкаталоги:");
        var folders = Directory.GetDirectories(path).ToList();
        foreach (var item in folders)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
        Console.WriteLine("Файлы:");
        var files = Directory.GetFiles(path).ToList();
        foreach (var item in files)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Введите символ...");
        var symbol = Convert.ToChar(Console.ReadLine());
        var filesForTransfer = files.Where(s => s.Remove(0, path.Length + 1)[..1].ToLower() == symbol.ToString().ToLower());

        var dirInfo = new DirectoryInfo(path);
        dirInfo.Create();
        dirInfo.CreateSubdirectory(symbol.ToString());
        var newPath = path + @"\" + symbol.ToString();
        Console.WriteLine(newPath);

        foreach (var item in filesForTransfer)
        {
            Console.WriteLine(item);
            var file = new FileInfo(item);
            file.MoveTo(newPath);
        }
    }
}
