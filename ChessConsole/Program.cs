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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem: "); //Origin
                        Position origin = Screen.ReadChessPosition().ToPosition();
                        match.CheckOriginPosition(origin);

                        Console.Clear();

                        bool[,] possiblePositions = match.Board.piece(origin).PossibleMoves();
                        Screen.PrintScreen(match.Board, possiblePositions);

                        Console.Write("Destino: "); //Destination
                        Position destination = Screen.ReadChessPosition().ToPosition();
                        match.CheckDestinationPosition(origin, destination);


                        match.PerformPlay(origin, destination);
                    }catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
