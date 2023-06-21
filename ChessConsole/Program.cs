using System;
using board;
using ChessGame;

namespace ChessConsole
{
    public class Program
    {
        public static void Main()
        {
            Board b = new Board(8, 8);

            b.AddPiece(new Rook (b, Color.Black), new Position(0, 0));
            b.AddPiece(new Knight (b, Color.Black), new Position(1, 3));
            b.AddPiece(new King (b, Color.Black), new Position(2, 4));

            Screen.PrintScreen(b);

            Console.ReadLine();
        }
    }
}
