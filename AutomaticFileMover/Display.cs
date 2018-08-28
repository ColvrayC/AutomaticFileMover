using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomaticFileMover
{
    public static class Display
    {
        public static void infosMessage(string message, bool clear = false)
        {
            if (clear)
                Display.Clear();
            Display.foreground(ConsoleColor.White);
            Console.WriteLine(message);
            Display.newLines(2);
        }

        public static void successMessage(string message, bool clear = false)
        {
            if (clear)
                Display.Clear();
            Display.foreground(ConsoleColor.Green);
            Console.WriteLine("> " + message);
            Display.newLines(2);
        }

        public static void errorMessage(string errorMessage, bool exit = false,bool stop = false)
        {
            Display.Clear();
            Display.foreground(ConsoleColor.Red);
            Console.WriteLine(errorMessage);
            Display.newLines(2);
            Console.WriteLine("L'application va se fermer dans quelques secondes...");
            if(!stop)
            {
                Thread.Sleep(5000);
                Environment.Exit(0);
                Display.Clear();
            }
        }
        public static void errorMessageWithoutExit(string errorMessage)
        {
            Display.Clear();
            Display.foreground(ConsoleColor.Red);
            Console.WriteLine(errorMessage);
            Display.newLines(2);
        }

        public static void foreground(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static string readLine(string text)
        {
            Display.foreground(ConsoleColor.White);
            Console.WriteLine(text ?? "");
            Display.newLines(1);
            Console.Write("> ");
            string str = Console.ReadLine();
            Display.newLines(2);
            return str;
        }

        public static void Title()
        {
            Display.foreground(ConsoleColor.Yellow);
            Console.WriteLine(@"================================================================================
    ___         __           _____ __                                      
   /   | __  __/ /_____     / __(_) /__     ____ ___  ____ _   _____  _____
  / /| |/ / / / __/ __ \   / /_/ / / _ \   / __ `__ \/ __ \ | / / _ \/ ___/
 / ___ / /_/ / /_/ /_/ /  / __/ / /  __/  / / / / / / /_/ / |/ /  __/ /    
/_/  |_\__,_/\__/\____/  /_/ /_/_/\___/  /_/ /_/ /_/\____/|___/\___/_/   
                                                                                ================================================================================        ");
        }

        public static void Clear()
        {
            Console.Clear();
            Display.Title();
        }

        public static void newLines(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine(Environment.NewLine);
                    break;
                case 2:
                    Console.WriteLine(Environment.NewLine + Environment.NewLine);
                    break;
                case 3:
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    break;
                case 4:
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    break;
            }
        }
    }
}
