﻿//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            string Menu = ("");//User Menu Choice.
            string textDataforAnalysis = "aaaaaaa";//Place Holder Data.
            Input TInput = new();//Creates Input Object.
            
            Console.Write("\n(M)anual or (F)ile Mode?\nTo Quit Press Q> ");//User Menu
            ConsoleKeyInfo menuChoice = Console.ReadKey();//User Menu Selection.
            if (menuChoice.Key == ConsoleKey.M)//Manual Mode Switch.
            {
                Console.WriteLine("\nManual Mode Selected.");
                textDataforAnalysis = TInput.manualTextInput();
            }

            else if (menuChoice.Key == ConsoleKey.F)//File Mode Switch.
            {

                try //Tries to open a file path.
                {
                    Console.WriteLine("\nFile Mode Selected.");
                    Console.WriteLine("\nIf your text file is not in the same directory as this Executable,\n Please enter the full path using forward as opposed to back slashes.\n");
                    Console.WriteLine("\nYou are currently in Directory: " + Directory.GetCurrentDirectory()); //Outputs current Directory to allow for the user to know where the program is executing from.
                    Console.Write("Enter File Path > ");
                    string path2File = Console.ReadLine()?? string.Empty;//File Path Getter.
                    textDataforAnalysis = TInput.fileTextInput(path2File);//Passes File Path String to Input Program.

                }
                catch (NullReferenceException)
                {
                    Console.Beep();
                    Console.WriteLine("File Path Not Provided.");
                    Main();
                }
                catch (FileNotFoundException)
                {
                    Console.Beep();
                    Console.WriteLine("File Not found where described.");
                    Main();
                }
            }
            
            else if (menuChoice.Key == ConsoleKey.Q)//Quit the Program Function.
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
            Analyse Counts = new();

            //Receive a list of integers back
            List<int> letterData = Counts.analyseText(textDataforAnalysis);

            //Report the results of the analysis
            //Tests whether the report ran successfully.
            Report reportOutput = new();
            bool reportSuccess = reportOutput.outputConsole(letterData, true);
            if (reportSuccess == true)
            {
                Console.WriteLine("Successfully Ran Report.");
            }
            else
            {
                Console.WriteLine("Failed to Run Report Successfully.");
            }


            //TO ADD: Get the frequency of individual letters? 

            //Gives the User the choice to re-run the program.
            Console.WriteLine("Press R to go again or Q to quit.");

            ConsoleKeyInfo rerunMenu = Console.ReadKey();
            if (rerunMenu.Key == ConsoleKey.R)
            {
                Main();
            }
            else if (rerunMenu.Key == ConsoleKey.Q)//Exit Program
            {
                Environment.Exit(0);
            }
        }
    }
}
           
     
        
        
    


