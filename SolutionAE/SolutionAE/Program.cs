using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionAE
{
    class Program
    {
        static string dataString = null;
        static string[] dataArray = null;
        static bool[] isValid;
        static int price = 0;
        static int despo = 0;
        static int c1;
        static int c2;
        static int c3;
        static int c4;
        static int tatle;
        static int difference;
        static void Main(string[] args)
        {
            string result;
            int sum = 0;
            result = Input();
            if (result =="Accept" )
            {
                Calculate();
                //Console.WriteLine("true!"+sum);
            }
            else
            {
                Console.WriteLine(result);
            }
            Console.ReadLine();

        }

        static private string Input()
        {
            
            dataString = Console.ReadLine();
            if (dataString != "")
            {
                dataArray = dataString.Split(' ');
                if (dataArray.Length < 2)
                {
                    return "Missing Input!";
                }
                else
                {
                    price = int.Parse(dataArray[0]);
                    despo = int.Parse(dataArray[1]);
                    if (price > 1000)
                    {
                        return "Error Input!";
                    }
                    if (despo < price)
                    {
                        return "Error,despo should lager than price!";
                    }
                    if (price % 10 != 5 && price % 10 != 0)
                    {
                        return "Error,Price must be divided by 5!";
                    }
                    difference = despo - price;
                    
                    return "Accept";
                }
            }
            else
            {
                return "Missing Input!";
            }
        }

        static private void Calculate()
        {
            while (difference > 0)
            {
                if (difference - 100 >= 0)
                {
                    c1++;
                    difference -= 100;
                }
                else if (difference - 25 >= 0)
                {
                    c2++;
                    difference -= 25;
                }
                else if (difference - 10 >= 0)
                {
                    c3++;
                    difference -= 10;
                }
                else if (difference - 5 >= 0)
                {
                    c4++;
                    difference -= 5;
                }
                tatle++;
            }

            Console.WriteLine(c1 + " "+ c2 + " " + c3 + " "+ c4 );
        }

    }
}
