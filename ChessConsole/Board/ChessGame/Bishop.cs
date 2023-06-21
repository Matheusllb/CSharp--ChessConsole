using board;

namespace ChessGame
{
    public class Bishop : Piece
    {
        public Bishop(Board b, Color c) : base(b, c)
        {

        }

        public override string ToString()
        {
            return "B"; //Bishop = Bispo
        }
    }
}
