// Welcome to my D&D Dice Roller! This was a programming challenge that I found on Reddit and decided to tackle!
// Created by Ryan Staudacher.
using System;
using System.Collections.Generic;

namespace DnD_Dice_Roller
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumNumber = 0;
            string line;
            string allNumbers = "";
            Random r = new Random();
            List<int> dieRolls = new List<int>();

            Console.WriteLine("Please type out which dice to roll, with each type of die being on its own line. " +
                "Use the format 'NdM', where N = number of dice to roll and M = type of die. \n\nExample: \n2d4\n3d6\n5d12\n\nType 'roll' on a new line when you are ready to roll the dice!");

            while((line = Console.ReadLine()) != "roll")
            {
                int dIndex;
                string firstNumberString;
                string secondNumberString;

                if(line.IndexOf('d') >= 1)
                {
                    dIndex = line.IndexOf('d');
                    firstNumberString = line.Substring(0, dIndex);
                    secondNumberString = line.Substring(dIndex + 1);

                    if (Int32.TryParse(firstNumberString, out int firstNumber) && Int32.TryParse(secondNumberString, out int secondNumber))
                    {
                        for (int i = 0; i < firstNumber; i++)
                        {
                            int newRoll = r.Next(1, secondNumber + 1);

                            dieRolls.Add(newRoll);
                        }
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

            for (int i = 0; i < dieRolls.Count; i++)
            {
                sumNumber += dieRolls[i];
            }

            for (int i = 0; i < dieRolls.Count; i++)
            {
                allNumbers += dieRolls[i] + ", ";
            }

            Console.WriteLine(sumNumber + ": " + allNumbers);

            Console.ReadKey();
        }
    }
}
