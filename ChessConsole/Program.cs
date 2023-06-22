using System;
using board;
using ChessGame;

namespace ChessConsole
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Board b = new Board(8, 8);

                ChessPosition pos = new ChessPosition('a', 1);

                Screen.PrintScreen(b);

                Console.WriteLine(pos);
                Console.WriteLine(pos.ToPosition());

                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
