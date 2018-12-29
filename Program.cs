//Jessica Wu
//Dec 28, 2018
//This is a Pig Latin String Game Project
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGame = true;
            string state=null;
            while (isGame)
            {
                //User Prompt to enter a word
                Console.ForegroundColor=ConsoleColor.Gray;
                Console.WriteLine("To convert a word to pig latin, press 1. To exit, press 2");
                state = Console.ReadLine();
                if (state == "1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Enter a word or phrase to be converted to Pig Latin");
                    //store the user input
                    string input = Console.ReadLine();
                    input = input.ToLower(); //convert all letters to lower case for convenience
                    string letter;
                    //always generate the pig latin convention for the start of the input
                    letter = input.Substring(0, 1)+"ay";
                    input=input.Remove(0,1);
                    //in case the input is a phrase instead of a word, fo through the characters to determine each individual word
                    int i = 0;
                    while(i < input.Length)
                    {
                        //whenever a space is detected, that means a start of a new word
                        if (input.ElementAt(i) == ' ')
                        {
                            //add the pig latin convention to the end of the last word
                            input=input.Insert(i,letter);
                            //move the index to the first letter of the next word
                            i += 4;
                            //obtain the initial letter of the next word
                            letter = input.Substring(i, 1) + "ay";
                            //remove the first letter from the next word
                            input=input.Remove(i,1);
                        }
                        //finish up inserting the convention for the last word
                        if (i == input.Length - 1)
                        {
                            input=input.Insert(i+1,letter);
                            break;
                        }
                        i++;
                    }
                    //change the output colour and output the result
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("The Pig Latin is "+ input);
                }
                else if (state == "2")
                {
                    //exit the game if the user presses 2
                    Console.ForegroundColor=ConsoleColor.DarkCyan;
                    Console.WriteLine("You have exited the game, see you next time");
                    isGame = false;
                }
                else
                {
                    //the user did not enter a valid option, prompt them to choose again
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter a valid option");
                }
                
            }

        }
    }
}
