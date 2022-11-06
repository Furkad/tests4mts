using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            FailProcess();
        }
        catch
        {

        }

        Console.WriteLine("Failed to fail process!");
        Console.ReadKey();
    }

    static void FailProcess()
    {
        //Быстрое завершение процесса после вывода сообщения
        Environment.FailFast("Successful fail!");

        //Завершает этот процесс и возвращает код выхода
        Environment.Exit(14);

        //Перезаполняет стек памяти, из-за чего вылетает ошибка переполнения
        Span<int> stackSpan1 = stackalloc int[150000];
        Span<int> stackSpan2 = stackalloc int[150000];
        Span<int> stackSpan3 = stackalloc int[150000];

        //Получает текущий процесс и завершает его
        Process.GetCurrentProcess().Kill();
    }
}
