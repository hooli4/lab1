using System;

namespace ConsoleApp6
{
    public static class Functions
    {
        public static void Main()
        {

        }

        public static int[] ex1(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = arr[i], index_min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        index_min = j;
                        min = arr[j];
                    }
                }

                int temp = arr[i];
                arr[i] = min;
                arr[index_min] = temp;

            }

            return arr;
        }
        public static bool ex2(string text)
        {
            text = text.ToLower();

            for (int i = 0; i <= (text.Length / 2) - 1; i++)
            {
                if (text[i] != text[text.Length - 1 - i]) return false;
            }

            return true;

        }
        public static int ex3(int number)
        {
            if (number < 0) throw new Exception("NotInRange");

            int count = 1;

            while (number != 1 && number != 0)
            {
                count *= number;
                number--;
            }

            return count;

        }

        public static int ex4(int order)
        {
            if (order <= 0) throw new Exception("NotInRange");

            return for_ex4.fib(order);

        }

        public static int ex5(string text, string sub_text)
        {
            if (sub_text.Length > text.Length || sub_text == "") return -1;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == sub_text[0])
                {
                    int save_i = i + 1;

                    for (int j = 0; j < sub_text.Length; j++)
                    {
                        if (text[i] != sub_text[j] || (i == text.Length - 1 && j != sub_text.Length - 1)) break;
                        else if (j == sub_text.Length - 1 && sub_text[j] == text[i]) return save_i;
                        else i++;
                    }

                    i = save_i;

                }

            }

            return -1;

        }
        public static bool ex6(int number)
        {

            if (number <= 0) throw new Exception("NotInRange");

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }

            return true;

        }
        public static int ex7(int number)
        {
            int flag = 0;
            string result = "";

            if (number < 0) flag = 1;

            number = Math.Abs(number);

            for (int i = number.ToString().Length - 1; i >= 0; i--)
            {
                result += number.ToString()[i];
            }

            return flag == 1 ? -Convert.ToInt32(result) : Convert.ToInt32(result);

        }
        public static string ex8(int number)
        {
            if (number < 1 || number > 3999) throw new Exception("NotInRange");

            string[] symbols = { "I", "V", "X", "L", "C", "D", "M" };

            string answer = "";

            while (number != 0)
            {

                if (number < 10)
                {
                    answer += for_ex8.intNum_into_RimNumber(number, symbols);
                    number -= number; ;
                }

                else
                {
                    answer += for_ex8.intNum_into_RimNumber(number, symbols);
                    number = number % ( (int) Math.Pow(10, number.ToString().Length - 1));
                }

            }

            return answer;
        }
    }

    public static class for_ex4
    {
        public static int fib(int order)
        {
            if (order == 1) return 0;
            else if (order == 2 || order == 3) return 1;
            else return fib(order - 1) + fib(order - 2);
        }
    }
    public static class for_ex8
    {
        public static string intNum_into_RimNumber(int number, string[] symbols)
        {
            int number_length = number.ToString().Length;
            int first_number = number / ((int) Math.Pow(10, number.ToString().Length - 1));

            if (first_number == 4) //4 --> IV 44 --> XLIV 444 --> CDXLIV
            {
                return symbols[2 * (number_length - 1)] + symbols[2 * (number_length - 1) + 1];
            }

            if (first_number == 9) //9 --> IX 99 --> XCIX 999 --> CMXCIX
            {
                return symbols[2 * (number_length - 1)] + symbols[2 * (number_length - 1) + 2];
            }

            if (first_number == 2 || first_number == 3 || first_number == 1)
            {
                switch(number_length)
                {
                    case 1:
                        return res(first_number, symbols, 1);
                    case 2:
                        return res(first_number, symbols, 2);
                    case 3:
                        return res(first_number, symbols, 3);
                    case 4:
                        return res(first_number, symbols, 4);
                }
            }

            if (first_number == 5)
            {
                switch(number_length)
                {
                    case 1:
                        return "V";
                    case 2:
                        return "L";
                    case 3:
                        return "D";
                }
            }

            if (first_number == 6 || first_number == 7 || first_number == 8)
            {
                switch (number_length)
                {
                    case 1:
                        return "V" + res(first_number, symbols, 1);
                    case 2:
                        return "L" + res(first_number, symbols, 2);
                    case 3:
                        return "D" + res(first_number, symbols, 3);
                }
            }

            return "";

        }

        public static string res(int first_number, string[] symbols, int Case) 
        {
            string result = "";

            first_number = first_number % 5;

            for (int i = 0; i < first_number; i++)
            {
                result += symbols[(Case - 1) * 2];
            }

            return result;

        }
    }
}
