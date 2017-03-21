﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Solution
{
    class Program
    {
        static string dictionaryString = null;
        static string[] dictionaryArray;
        static Int64 problemCount = 0;
        static int testCaseCount = 0;
        static List<string> inputDataList = new List<string>();
        static List<List<string>> finalList1 = new List<List<string>>();
        static void Main(string[] args)
        {
            bool result;
            result=Input();
            if (result == true)
            {
                //Console.WriteLine("complete!");
                Console.WriteLine(DateTime.Now.Ticks);
                finalList1=Calculate();
                foreach (List<string> stList in finalList1 )
                {
                   foreach(string stArray in stList)
                   {
                        Console.Write(stArray+" ");
                   }
                    Console.WriteLine();
                }
                Console.WriteLine(DateTime.Now.Ticks);
            }
            else
            {
                Console.WriteLine("false!");
            }
            Console.ReadLine();
        }

        private static List<List<string>> Calculate()
        {
            List<List<string>> finalList = new List<List<string>>();
           
            foreach (string inputdata in inputDataList)
            {
                List<string> resultArray = new List<string>(); 
                bool[] isUsed = new bool[26];
                bool isAnswer = false;
                int[] usedCount=new int[26];
                char[] inputArray;
                int k=0;
                int m = 0;
                char[] dictionaryCharArray;
                
                for (int i = 0; i < 26; i++)
                {
                    isUsed[i] = false;
                    usedCount[i]=0;
                }
                inputArray = inputdata.ToCharArray();
                for (int i = 0; i < inputArray.Length; i++)
                {
                    isUsed[inputArray[i] - 97] = true;
                }

                for (int i = 0; i < dictionaryArray.Length; i++)
                {
                    k = 0;
                    dictionaryCharArray=dictionaryArray[i].ToCharArray();
                    for (int j = 0; j < dictionaryCharArray.Length; j++)
                    {
                        if (isUsed[dictionaryCharArray[j] - 97] == false)
                        {
                            isAnswer = false;
                            break;
                        }
                        else
                        {
                            usedCount[dictionaryCharArray[j] - 97]++;
                            isAnswer = true;
                        }
                    }
                    if (isAnswer != false)
                    {
                        for (int j = 0; j < 26; j++)
                        {
                            if (usedCount[j] != 0)
                                k++;
                        }
                        if (k == inputdata.Length)
                        {
                            resultArray.Add(dictionaryArray[i]);
                        }
                    }
                   
                }
                resultArray.Sort();
                finalList.Add(resultArray); 
            }
            return finalList;
            
            
        }
        private static bool Input()
        {
            problemCount = Int64.Parse(Console.ReadLine());
            if (problemCount < 1 || problemCount > 4 * Math.Pow(10, 10))
            {
                return false;
            }
            else
            {

                dictionaryString = Console.ReadLine();
                dictionaryArray =dictionaryString.Split(' ');
                if (dictionaryArray.Length != problemCount)
                {
                    return false;
                }
                else
                {

                    testCaseCount = int.Parse(Console.ReadLine());

                    if (testCaseCount > Math.Pow(10, 6) || testCaseCount < 1)
                    {
                        return false;
                    }
                    else
                    {
                        int i = 0;
                        string inputData = null;
                        while (i < testCaseCount)
                        {
                            inputData = Console.ReadLine();
                            inputDataList.Add(inputData);
                            i++;
                        }
                        return true;
                    }
                }

            }

            
            
           
        }

       
    }
}