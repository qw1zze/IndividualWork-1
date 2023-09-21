using System.Text;
using InstrumentsLibrary;

public partial class Program
{
    /// <summary>
    /// Add Instrument to the list.
    /// </summary>
    static void AddInstrument(string[] data, List<Instrument> instruments)
    {
        if (data[0] == "Drum")
        {
            if (!double.TryParse(data[1], out double volume) ||
                !int.TryParse(data[2], out int mastery))
            {
                throw new Exception("Файл имеет неверную структуру");
            }
            instruments.Add(new Drum(volume, mastery));
        }
        else if (data[0] == "Guitar")
        {
            if (!double.TryParse(data[1], out double volume) ||
                !int.TryParse(data[2], out int mastery))
            {
                throw new Exception("Файл имеет неверную структуру");
            }
            instruments.Add(new Guitar(volume, mastery));
        }
        else
        {
            throw new Exception("Файл имеет неверную структуру");
        }
    }

    /// <summary>
    /// Method for get inforamtion from user file.
    /// </summary>
    static void GetInfo(string[] lines, List<Instrument> instruments, out double resultForDrums, out double resultForGuitars)
    {
        //throw exceptions if file empty or have not enough lines
        if (lines.Length == 0)
        {
            throw new Exception("Файл пуст, попробуйте другой файл");
        }
        if (lines.Length < 4)
        {
            throw new Exception("В файле недостаточно строк(должно быть минимум 4)");
        }

        //Add instruments from file
        for (int i = 0; i < lines.Length - 3; i++)
        {
            //Check line is empty
            if (string.IsNullOrEmpty(lines[i]))
            {
                throw new Exception("Файл содержит пустую строку!");
            }

            string[] dataFromLine = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            AddInstrument(dataFromLine, instruments);
        }

        resultForDrums = 0;
        resultForGuitars = 0;

        //Get min result from file
        if (!double.TryParse(lines[^2].Split(" ", StringSplitOptions.RemoveEmptyEntries)[^1], out resultForDrums) ||
            !double.TryParse(lines[^1].Split(" ", StringSplitOptions.RemoveEmptyEntries)[^1], out resultForGuitars))
        {
            throw new Exception("Файл имеет неверную структуру");
        }
    }

    /// <summary>
    /// Method for create file for Drums and Guitars
    /// </summary>
    static void CreateFile(string type, List<Instrument> instruments, double resultForDrums, double resultForGuitars)
    {
        if (type == "Drum")
        {
            List<string> drums = new List<string>();

            foreach (var instr in instruments)
            {
                if (instr is Drum && ((Drum)instr).Play() > resultForDrums)
                {
                    drums.Add(((Drum)instr).ToString());
                }
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            File.WriteAllLines($"{type}.txt", drums.ToArray(), Encoding.GetEncoding(1251));
        }
        else if (type == "Guitar")
        {
            List<string> guitars = new List<string>();

            foreach (var instr in instruments)
            {
                if (instr is Guitar && ((Guitar)instr).Play() > resultForGuitars)
                {
                    guitars.Add(((Guitar)instr).ToString());
                }
            }

            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            File.WriteAllLines($"{type}.txt", guitars.ToArray(), Encoding.GetEncoding(1251));
        }
        Console.WriteLine("Файл успешно создан!");
    }

    /// <summary>
    /// Continue program according user input
    /// </summary>
    static bool CheckContinue()
    {
        Console.Write("Нажмите 'Q', чтобы выйти или любую клавишу, чтобы продолжить: ");

        var key = Console.ReadKey().Key;

        Console.WriteLine();

        if (key != ConsoleKey.Q)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Get File name from user
    /// </summary>
    static string InputFileName()
    {
        Console.Write("Введите название файла: ");
        return Console.ReadLine();
    }
}