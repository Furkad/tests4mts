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

            public static string operator +(Number n1, string n2)//����������� �������� ��������
            {
                /*
                 * ���������� ������, � ������� ��� ������� ������������ ����������� ��������� ��������:
                 * �� ������ ���������� ���� ���� �������� Number (�.�. _number);
                 * ������ ���������� �� ��������� �� ������ � ��� ������ ������ Parse()
                 * �� ���������� ������ Int32 ��������� ��������� �������� � �������������
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