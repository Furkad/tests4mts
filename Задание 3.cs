static class Program
{
    static void Main(string[] args)
    {
        foreach (var item in new[] { 1, 2, 3, 4 }.EnumerateFromTail(2))
        {
            Console.WriteLine(item);
        }
    }

    /// <summary>
    /// <para> ��������� ��������� ��������� � ����� </para>
    /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="tailLength">������� ��������� ��������� � �����  (� ���������� �������� tail = 0)</param>
    /// <returns></returns>
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        //���� ���������� ��������� � ����� �� ����������, ��� ������ ��� ����� ����, �� ������������ ������ ������
        if (tailLength == null || tailLength <= 0)
            return new List<(T item, int? tail)>();

        //������ ���� ����������� ������
        List<(T item, int? tail)> items = new List<(T item, int? tail)>();
        //��������� ������� � ����������� ��� �������� ����� ������
        int count = enumerable.Count();
        //���� ���������� ������ ��� ������� ��������� ������ ��� ����� ��� ����� ���������
        if (tailLength >= count)
        {
            //����� ��������� ��� ��������, ������� �������� ������� � �������� ���
            foreach (var item in enumerable)
                items.Add((item, --count));
        }
        else
        {
            //���� ���������� ������ ��������� ������ ����� ���������
            //�� ���������� ���, ����������� ���������� ������ ����������
            int i = 0;
            int re = count - (int)tailLength;
            foreach (var item in enumerable)
            {
                items.Add((item, i >= re ? --tailLength : null));
                i++;
            }
        }
        //���������� ��������� ���������
        return items;
    }

}