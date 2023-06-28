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

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            // North East
            Position pos = new Position(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }

            // Southeast
            pos = new Position(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
            }

            // South-West
            pos = new Position(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
            }

            // Northwest
            pos = new Position(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
            }

            return matrix;
        }
    }
}
