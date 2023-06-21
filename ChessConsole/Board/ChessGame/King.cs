using board;

namespace ChessGame
{
    public class King : Piece
    {
        public King(Board b, Color c) : base(b, c)
        {

        }

        public override string ToString()
        {
            return "R"; //King = Rei
        }
    }
}
