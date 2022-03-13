using System;

namespace Lab3
{
    internal static class Program
    {
        // 1000000100000100001000100000 - корректна
        // 100000100000100001000100000 - некорректна
        public static void Main()
        {
            Console.WriteLine("Введите входную строку:");
            var input = Console.ReadLine();

            Console.WriteLine(IsTuring(input) ? "Машина Тьюринга корректна" : "Машина Тьюринга НЕкорректна");
        }

        private static bool IsTuring(string input)
        {
            if (input.EndsWith("1"))  return false;

            var zeroes = input.Split(new[] { '1' }, StringSplitOptions.RemoveEmptyEntries);

            if (zeroes.Length % 5 != 0) return false;

            var index = 1;
            foreach (var chunk in zeroes)
            {
                var countZero = chunk.Length;
                switch (index)
                {
                    case 1:
                    case 3:
                        if (countZero <= 2 || countZero % 2 != 0) return false;
                        break;
                    case 2:
                    case 5:
                        if (countZero <= 3 || countZero % 2 == 0)  return false;
                        break;
                    case 4:
                        if (countZero < 1 || countZero > 3)  return false;
                        break;
                }

                index = index == 5 ? 1 : index + 1;
            }

            return true;
        }
    }
}