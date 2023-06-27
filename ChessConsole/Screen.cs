using board;
using ChessGame;

namespace ChessConsole
{
    public class Screen
    {
        public static void PrintScreen(Board board)
        {
            for(int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " |  ");
                for (int j = 0; j < board.Columns; j++)
                {
                   PrintPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ------------------------");
            Console.WriteLine("     a  b  c  d  e  f  g  h");
        }

        public static void PrintScreen(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " |  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j] == true)
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ------------------------");
            Console.WriteLine("     a  b  c  d  e  f  g  h");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece) 
        {
            if (piece == null)
            {
                Console.Write("-  ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor standardColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = standardColor;
                }
                Console.Write("  ");
            }
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
    }
}
