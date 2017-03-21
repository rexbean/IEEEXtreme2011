using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AG
{
    class Program
    {
        struct a
        {
            public int number;
            public int times;
        };
        static List<a> aList = new List<a>();
        static string dataString = null;
        static string[] dataArray = null;
        static int L1;
        static int L2;
        static int L3;
        static void Main(string[] args)
        {
            bool result=false;
            bool newResult = false;
            int sum = 0;
            result = Input();
            if (result == true)
            {
                 
                
                
                Calculate();
                 foreach (a a1 in aList)
                 {
                     if (a1.number == L3)
                     {
                         Console.WriteLine(a1.times);
                         newResult = true;
 
                     }
                 }
                 if (newResult == false)
                 {
                     Console.WriteLine("no");
 
                 }
               
            }
            else
            {
                Console.WriteLine("false!");
            }
            Console.ReadLine();
        }
        private static bool Input()
        {
            dataString = Console.ReadLine();
            if (dataString != "")
            {
                dataArray = dataString.Split(' ');
                if (dataArray.Length < 3)
                {
                    return false;
                }
                else
                {
                    L1 = int.Parse(dataArray[0]);
                    L2 = int .Parse(dataArray[1]);
                    L3 = int.Parse(dataArray[2]);
                    if (L2 > L1)
                    {
                        int temp = L2;
                        L2 = L1;
                        L1 = temp;
                    }
                    return true;
                }
                   



            }
            else
                return false;
        }

        private static void Calculate()
        {
            
            int sL1=L1;
            int sL2=0;
            int j = 0;
            int times = 1;
            bool isOver = false;
            while (L2 * j < L1)
            {
                j++;
            }
            a a1=new a();
            a1.number = L2 * j - L1;
            a1.times = j * 2;
            aList.Add(a1);

            while (isOver==false)
            {
                a a2 = new a();
                int difference = sL1 - L2 + sL2;
                if (difference > L2)
                {
                    
                    a2.number = difference;
                    times += 1;
                    a2.times = times;
                    //aList.Add(a2);
                    sL2 = 0;
                    sL1 = difference;
                    times++;
                }
                else if (difference < L2)
                {
                    //a a2 = new a();
                    a2.number = difference;
                    //aList.Add(a2);
                    if (sL2 + sL1 > L2)
                    {
                        sL2 = L2;
                        times++;
                        
                        sL1 = difference;
                        //times++;
                        a2.times = times;
                        sL2 = 0;
                        times++;
                        sL1 = L1;
                        times++;
                        sL2 = difference;
                        times++;
                        //sL2 = L2;
                        //times++;
                        //sL1 = L1;
                        //times++;
                        //times += 2;
                        
                    }
                    else
                    {
                        
                        sL2 = sL2 + sL1;
                        times++;
                        sL1 = L1;
                        times++;
                        sL1 = L1;
                        times++;
                       // times += 4;

                    }
                    //a2.times = times;
                }
                for (int i = 1; i < aList.Count; i++)
                {
                    if (aList[i].number != a2.number)
                    {

                        continue;
                    }
                    else
                        isOver = true;
 
                }
                if (isOver == false)
                {
                    //a2.times++;
                    aList.Add(a2);
                }
            }
 
        }
    }
}
