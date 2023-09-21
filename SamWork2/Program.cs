using InstrumentsLibrary;

public partial class Program
{
    static void Main()
    {
        do
        {
            try
            {
                List<Instrument> instruments = new List<Instrument>();

                string[] inputLines = File.ReadAllLines(InputFileName());

                GetInfo(inputLines, instruments, out double resultForDrums, out double resultForGuitars);
                
                CreateFile("Drum", instruments, resultForDrums, resultForGuitars);

                CreateFile("Guitar", instruments, resultForDrums, resultForGuitars);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не существует!");
            }
            catch (IOException)
            {
                Console.WriteLine("Имя файла содержит недопустимые символы");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Имя файла не может быть пустым");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        } while (CheckContinue());
    }
}