// Welcome to my D&D Dice Roller! This was a programming challenge that I found on Reddit and decided to tackle!
// Created by Ryan Staudacher.
using System;
using System.Collections.Generic;

namespace DnD_Dice_Roller
{
    class Program
    {
        private static string line;

        private static void Main(string[] args)
        {
            DiceRoller();
        }

        private static void DiceRoller()
        {
            List<List<int>> dieRolls = new List<List<int>>();
            Random r = new Random();
            string allNumbers = "";
            int totalSum = 0;

            Console.WriteLine("Please type out which dice to roll, with each type of die being on its own line. " +
                "Use the format 'NdM', where N = number of dice to roll and M = type of die. \n\nExample: \n2d4\n3d6\n5d12\n\nType 'roll' on a new line when you are ready to roll the dice!");

            // While the user has not entered 'roll' on a new line
            while ((line = Console.ReadLine()) != "roll")
            {
                int dIndex;
                string firstNumberString;
                string secondNumberString;

                // Detects if there is a 'd' somewhere on the current line. If not, output error message.
                if (line.IndexOf('d') >= 1)
                {
                    // Gets the 'd' ;)
                    dIndex = line.IndexOf('d');
                    // Gets the string of the number that is before the 'd'
                    firstNumberString = line.Substring(0, dIndex);
                    // Gets the string of the number that is after the 'd'
                    secondNumberString = line.Substring(dIndex + 1);

                    // If the two substrings are able to be parsed into two numbers, do something, if not output error message
                    if (Int32.TryParse(firstNumberString, out int firstNumber) && Int32.TryParse(secondNumberString, out int secondNumber))
                    {
                        List<int> l = new List<int>();

                        // Roll each die and add it to the sublist
                        for (int i = 0; i < firstNumber; i++)
                        {
                            int newRoll = r.Next(1, secondNumber + 1);

                            l.Add(newRoll);
                        }

                        // Add the sublist to the dieRolls list
                        dieRolls.Add(l);
                    }
                    else
                    {
                        Console.WriteLine("That is not the correct format. Please try again with the correct format.");
                    }
                }
                else
                {
                    Console.WriteLine("That is not the correct format. Please try again with the correct format.");
                }
            }

            // For aestethic reasons :D
            Console.WriteLine("");
            
            foreach (List<int> l in dieRolls)
            {
                int sumNumber = 0;
                string allNumbersInList = "";

                // Takes each roll in each sublist and adds them together to get the sum.
                // Takes each roll in each sublist and adds it to a string so the user can see what each roll was.
                for (int i = 0; i < l.Count; i++)
                {
                    sumNumber += l[i];
                    totalSum += l[i];
                    allNumbers += l[i] + ", ";

                    if (i == (l.Count - 1))
                    {
                        allNumbersInList += l[i] + "";
                    }
                    else
                    {
                        allNumbersInList += l[i] + ", ";
                    }
                }

                Console.WriteLine(sumNumber + ": " + allNumbersInList);
            }

            Console.WriteLine("\nTotal - " + totalSum + ": " + allNumbers);

            Console.ReadKey();
        }
    }
}
