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

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(Position.Line, Position.Column);

            //up
            pos.DefineValues(pos.Line - 1, pos.Column);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if(Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //Down
            pos.DefineValues(pos.Line + 1, pos.Column);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if(Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //Right
            pos.DefineValues(pos.Line, pos.Column + 1);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            //Left
            pos.DefineValues(pos.Line, pos.Column - 1);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return matrix;
        }
    }
}
