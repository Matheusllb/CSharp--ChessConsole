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

                b.AddPiece(new King(b, Color.Black), new Position(0, 0));
                b.AddPiece(new Rook(b, Color.Black), new Position(1, 3));
                b.AddPiece(new Queen(b, Color.Black), new Position(4, 2));
                b.AddPiece(new Knight(b, Color.Black), new Position(5, 4));

                b.AddPiece(new Bishop(b, Color.White), new Position(7, 2));
                b.AddPiece(new Pawn(b, Color.White), new Position(7, 4));
                b.AddPiece(new Pawn(b, Color.White), new Position(6, 3));
                b.AddPiece(new King(b, Color.White), new Position(6, 0));

                Screen.PrintScreen(b);

                Console.ReadLine();
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
