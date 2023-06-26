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
                    
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("-  ");
                    }
                    else
                    {
                        PrintPiece(board.piece(i, j));
                        Console.Write("  ");

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   ------------------------");
            Console.WriteLine("     a  b  c  d  e  f  g  h");
        }

        public static void PrintPiece(Piece piece) 
        {
            if(piece.Color == Color.White)
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
