using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to check:");
            string strinput = Console.ReadLine();

            // DFA Logic
            string Initial_State = "S0";
            string Final_State = "S3";

            var dict = new Dictionary<string, Dictionary<char, object>>();
            dict.Add("S0", new Dictionary<char, object>()
            {
                { 'a', "S1" },
                { 'b', "Se" },
                { 'c', "Se" }
            });
            dict.Add("S1", new Dictionary<char, object>()
            {
                { 'a', "Se" },
                { 'b', "S2" },
                { 'c', "Se" }
            });
            dict.Add("S2", new Dictionary<char, object>()
            {
                { 'a', "Se" },
                { 'b', "Se" },
                { 'c', "S3" }
            });
            dict.Add("S3", new Dictionary<char, object>()
            {
                { 'a', "Se" },
                { 'b', "Se" },
                { 'c', "S3" }
            });

            char check;
            string state;

            char[] charinput = strinput.ToCharArray();

            if (charinput.Length == 0)
            {
                Console.WriteLine("ERROR: Empty Input");
                return;
            }

            check = charinput[0];
            state = Initial_State;
            int j = 0;

            try
            {
                while (check != '\\' && state != "Se")
                {
                    state = dict[state][check] + "";
                    j++;

                    if (j < charinput.Length)
                    {
                        check = charinput[j];
                    }
                    else
                    {
                        check = '\\'; // End of string logic
                    }

                }

                if (state.Equals(Final_State))
                {
                    Console.WriteLine("RESULT OKAY");
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("ERROR: Invalid input character");
            }

            Console.ReadKey(); // Keep console open until key pressed
        }
    }
}