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
    /// <para> Отсчитать несколько элементов с конца </para>
    /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
    /// </summary> 
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <param name="tailLength">Сколько элементов отсчитать с конца  (у последнего элемента tail = 0)</param>
    /// <returns></returns>
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        //если количество элементов с конца не приводится, или меньше или равно нулю, то возвращается пустой список
        if (tailLength == null || tailLength <= 0)
            return new List<(T item, int? tail)>();

        //Создаём свой собственный список
        List<(T item, int? tail)> items = new List<(T item, int? tail)>();
        //Объявляем счётчик и присваиваем ему значение длины списка
        int count = enumerable.Count();
        //Если количество нужных для отсчёта элементов больше или равно чем длина коллекции
        if (tailLength >= count)
        {
            //тогда добавляем все элементы, попутно уменьшая счётчик и добавляя его
            foreach (var item in enumerable)
                items.Add((item, --count));
        }
        else
        {
            //если количество нужных элементов меньше длины коллекции
            //то перебираем все, паралелльно отсчитывая нужное количество
            int i = 0;
            int re = count - (int)tailLength;
            foreach (var item in enumerable)
            {
                items.Add((item, i >= re ? --tailLength : null));
                i++;
            }
        }
        //возвращаем коллекцию элементов
        return items;
    }

}
