using board;

namespace ChessGame
{
    public class Pawn : Piece
    {
        public Pawn(Board b, Color c) : base(b, c)
        {

        }

        public override string ToString()
        {
            return "P"; //Pawn = Peão
        }
    }
}
