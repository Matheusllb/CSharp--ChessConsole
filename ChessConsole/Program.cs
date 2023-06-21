using System;
using board;

namespace ChessConsole
{
    public class Program
    {
        public static void Main()
        {
            Board b = new Board(8, 8);

            Screen.PrintScreen(b);

            Console.ReadLine();
        }
    }
}
