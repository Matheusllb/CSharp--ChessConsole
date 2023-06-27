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
                ChessMatch match = new ChessMatch();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintScreen(match.Board);

                    Console.WriteLine();
                    Console.Write("Origem: "); //Origin
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    Console.Clear();

                    bool[,] possiblePositions = match.Board.piece(origin).PossibleMoves();
                    Screen.PrintScreen(match.Board, possiblePositions);

                    Console.Write("Destino: "); //Destination
                    Position destination = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteMoviment(origin, destination);
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
