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
        //������� ���������� �������� ����� ������ ���������
        Environment.FailFast("Successful fail!");

        //��������� ���� ������� � ���������� ��� ������
        Environment.Exit(14);

        //������������� ���� ������, ��-�� ���� �������� ������ ������������
        Span<int> stackSpan1 = stackalloc int[150000];
        Span<int> stackSpan2 = stackalloc int[150000];
        Span<int> stackSpan3 = stackalloc int[150000];

        //�������� ������� ������� � ��������� ���
        Process.GetCurrentProcess().Kill();
    }
}