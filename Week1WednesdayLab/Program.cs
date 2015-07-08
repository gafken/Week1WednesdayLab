using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1WednesdayLab
{
    class Program
    {
        static void Main(string[] args)
        {
            incomeTax(args);
            //timeAndClassifications();
        }

        static void incomeTax(string[] args)
        {
            double income = 0;
            bool parse = false;
            if (args.Length > 0)                                //Check if args are available to parse
                parse = double.TryParse(args[0], out income);   //Try to parse first comand line var
            Console.WriteLine("Welcome to Income Tax Calculator™.");
            Console.WriteLine("\nPlease press enter to continue");
            Console.ReadLine();
            if (!parse || income < 0)                           //Failsafe for user input if TryParse fails or no args are avail.
                Console.WriteLine("\n\nInvalid Command Line Argument, please enter income amount above 0:\n");
            while (!parse || income < 0)
            {
                parse = double.TryParse(Console.ReadLine(), out income);

                if (!parse || income < 0)
                    Console.WriteLine("\n\nInvalid input, please input a number above 0 without any comma's or letters:\n");
            }
            double taxOwed = 0;                             //Worded as 5% tax is owed on the first 20,000 of income
            if (income >= 75000)                            //10% tax is owed on all income over 20,000
            {                                               //20% tax is owed on all income over 50,000
                double tempIncome = income - 75000;         //35% tax is owed on all income over 75,000
                taxOwed = (tempIncome * .35) + 9000;
            }                                               //Instructed to infer the mean when asking and decided to 
            else if (income >= 50000)                       //go with the more complex resolution to test my skills more
            {
                double tempIncome = income - 50000;
                taxOwed = (tempIncome * .2) + 4000;
            }
            else if (income >= 20000)
            {
                double tempIncome = income - 20000;
                taxOwed = (tempIncome * .05) + 1000;
            }
            else
                taxOwed = income * .05;
            Console.WriteLine(string.Format("The tax owed on {0:C2} is {1:C2}", income, taxOwed));
        }

        static void timeAndClassifications()
        {
            int second = DateTime.Now.Second;
            switch (second)
            {
                case 0:
                    Console.WriteLine("The new minute has just begun");
                    break;
                case 15:
                    Console.WriteLine("We're one quarter done");
                    break;
                case 30:
                    Console.WriteLine("Half way there");
                    break;
                case 45:
                    Console.WriteLine("Getting close to done");
                    break;
                default:
                    Console.WriteLine("Working on it.");
                    break;
            }
        }

        static void loops()
        {
            for (int i = 1; i < 101; i++)
            {
                Console.Write(i + " ");
                if (i % 3 == 0)
                    Console.Write("Fizz");
                if (i % 5 == 0)
                    Console.Write("Buzz");
                Console.WriteLine();
            }
        }

        static void reverse(string words)
        {
            for (int i = words.Length - 1; i > -1; i--)
            {
                Console.Write(words[i]);
            }
        }

        static void stringSquared(string[] book)
        {
            foreach(string page in book.Reverse())
            {
                for (int i = page.Length - 1; i > -1; i--)
                    Console.Write(page[i]);
                Console.WriteLine();
            }
        }


    }
}
