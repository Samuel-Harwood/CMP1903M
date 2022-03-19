﻿//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {

            //Local list of integers to hold the first five measurements of the text
           // public List<int> parameters = new List<int>();

        //Create 'Input' object
        //Get either manually entered text, or text from a file
            string Menu = ("");
            string textDataforAnalysis = "aaaaaaa";
            Input TInput = new Input();
            
            Console.Write("\n(M)anual or (F)ile Mode?\nTo Quit Press Q> ");
            ConsoleKeyInfo menuChoice = Console.ReadKey();
            if (menuChoice.Key == ConsoleKey.M)
            {
                Console.WriteLine("\nManual Mode Selected.");
                textDataforAnalysis = TInput.manualTextInput();
            }

            else if (menuChoice.Key == ConsoleKey.F)
            {
                try{
                    Console.WriteLine("\nFile Mode Selected.");
                    Console.Write("Enter File Path > ");
                    string path2File = Console.ReadLine();
                    textDataforAnalysis = TInput.fileTextInput(path2File);
                    
                }
                catch(NullReferenceException){
                    Console.Beep();
                    Console.WriteLine("File Path Not Provided.");
                    Main();
                }

                

            }
            else if (menuChoice.Key == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine();
                Main();
            }
        //Create an 'Analyse' object
        //Pass the text input to the 'analyseText' method
            Analyse Counts = new Analyse();
            Counts.analyseText(textDataforAnalysis);

            //Receive a list of integers back

            //Report the results of the analysis


            //TO ADD: Get the frequency of individual letters? 

            Console.ReadKey();
        }
    }
}
           
     
        
        
    


