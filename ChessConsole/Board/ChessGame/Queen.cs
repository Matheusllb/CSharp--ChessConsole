using board;

namespace ChessGame
{
    public class Queen : Piece
    {
            public Queen(Board b, Color c) : base(b, c)
            {

            }

            public override string ToString()
            {
                return "D"; //Queen = Dama (Rainha)
            }
    }
}
