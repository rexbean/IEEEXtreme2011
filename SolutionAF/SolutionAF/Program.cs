using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolutionAF
{
    class Program
    {

        static string dataString = null;
        static string[] dataArray = null;
        static bool[] isValid;
        static List<receipt> receiptList = new List<receipt>();

        static void Main(string[] args)
        {
            bool result;
            int sum = 0;
            result = Input();
            if (result == true)
            {
                sum=Calculate();
                Console.WriteLine("true!"+sum);
            }
            else
            {
                Console.WriteLine("false!");
            }
            Console.ReadLine();

        }

        struct receipt
        {
            public string VAT;
            public string price;
            public bool isValid;
        };
        private static bool Input()
        {           
            dataString= Console.ReadLine();
            while(dataString!="")
            {
                dataArray = dataString.Split(' ');
                if (dataArray.Length == 2)
                {
                    receipt r = new receipt();
                    if (dataArray[0].Length == 8 || dataArray[0].Length == 9)
                    {
                        if (dataArray[0].Length == 8)
                        {
                            r.VAT = dataArray[0].Insert(0, "0");
                        }
                        else
                        {
                            r.VAT = dataArray[0];
                        }
                        r.price = dataArray[1];
                        r.isValid = true;
                        receiptList.Add(r);
                    }
                    else
                    {
                        r.VAT = dataArray[0];
                        r.price = dataArray[1];
                        r.isValid = false;
                        receiptList.Add(r);
                    }
                    
                }
                else
                {
                    return false;
                }
                dataString = Console.ReadLine();
            }
            return true;




        }

        private static int Calculate()
        {
            double S = 0;
            double Y = 0;
            int sum = 0;
            for (int i = 0; i < receiptList.Count;i++ )
            {
                S = 0;
                if (receiptList[i].isValid == false)
                {
                    continue;
                }
                else
                {
                    for (int j = 1; j < 9; j++)
                    {
                        S += (receiptList[i].VAT[8-j] - 48) * Math.Pow(2, j);
                    }
                }
                Y = S % 11;
                if (Y == 10 && (receiptList[i].VAT[8]-48) == 0||(receiptList[i].VAT[8]-48)==Y)
                {
                    receipt newReceipt = new receipt();
                    newReceipt = receiptList[i];
                    newReceipt.isValid = true;
                    receiptList[i]=newReceipt;
                    sum += int.Parse(newReceipt.price);
                }
                
            }
            return sum;
          
        }
    }
}
