using board;

namespace ChessGame
{
    public class Rook : Piece
    {
        public Rook(Board b, Color c) : base(b, c)
        {

        }

        public override string ToString()
        {
            return "T"; // Rook = Torre
        }
    }
}
