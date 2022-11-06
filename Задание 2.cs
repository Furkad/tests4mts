using System.Globalization;

class Program
    {
        static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

        class Number
        {
            readonly int _number;

            public Number(int number)
            {
                _number = number;
            }

            public override string ToString()
            {
                return _number.ToString(_ifp);
            }

            public static string operator +(Number n1, string n2)//ïåðåãðóæàåì îïåðàòîð ñëîæåíèÿ
            {
                /*
                 * Возвращаем строку, в которой при помощии интерполяции высчитываем результат сложения:
                 * Из первой переменной берём само значение Number (т.е. _number);
                 * Вторую переменную мы принимаем за строку и при помощи метода Parse()
                 * из системного класса Int32 переводим строковое значение в целочисленное
                 */
                return new string($"{n1._number + Int32.Parse(n2)}");
            }
        }

        static void Main(string[] args)
        {
            int someValue1 = 10;
            int someValue2 = 5;

            string result = new Number(someValue1) + someValue2.ToString(_ifp);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
