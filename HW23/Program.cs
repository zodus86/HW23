using System;
using System.Collections.Generic;
using System.Linq;

namespace HW23
{
    public static class HomeWorkParser
    {  
        public static int ToIntByChar (char c)
        {
            return c - '0';
        }

        public static double MyParse(this string text)
        {
            char[] delitel = { ',', '.' };
            double result = 0;
            bool negativ = false;
            
            double drobResult = 0;

            if (text.Length == 0)
                throw new ArgumentException(message: "пустой текст");

            //0 до делителя 1 после
            string[] array = text.Split(delitel);

            List<char> listChars = array[0].ToList();
            if(listChars[0] == '-')
            {
                negativ = true;
                listChars.Remove('-');
            }

            if (array.Length > 2 )
                throw new ArgumentException(message: "Слишком много делителей");

            if(listChars.Count() > 0)
            {
                for (int i = 0; i < listChars.Count(); i++)
                {
                    if (listChars[i] < '0' || listChars[i] > '9') throw new ArgumentException();
                    result = checked(result * 10 + ToIntByChar(listChars[i]));
                }
            }

            if(array.Length > 1)
            {
                listChars = array[1].ToList();
                for (int i = 0; i < listChars.Count(); i++)
                {
                    if (listChars[i] < '0' || listChars[i] > '9') throw new ArgumentException();
                        drobResult = checked(drobResult * 10 + ToIntByChar(listChars[i]));
                }

                drobResult = drobResult / (Math.Pow(10, listChars.Count()));

            }

            result = result + drobResult;

            return (negativ) ? -result : result;




            /*
             foreach (var item in array[0])
                Console.WriteLine(ToIntByChar(item));
             */
           
        }
    }





    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите число");
            string text = Console.ReadLine();

            Console.WriteLine($"{text} пробуем приоброзвовать");
            
            double newItem = text.MyParse();
            Console.WriteLine($"удачно! {newItem} тип {newItem.GetType()}");
            
            //Console.WriteLine($"{"555,544449".MyParse()} _ удачно!");
            //Console.WriteLine($"{"-9955.45".MyParse()} _ удачно!");
            //Console.WriteLine($"{"-09955.45009".MyParse()} _ удачно!");
        }



    }
}
