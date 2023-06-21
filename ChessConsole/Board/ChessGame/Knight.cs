using board;

namespace ChessGame
{
    public class Knight : Piece
    {
        public Knight(Board b, Color c) : base(b, c)
        {

        }

        public override string ToString()
        {
            return "C"; //Knight = Cavalo (Cavaleiro)
        }
    }
}
