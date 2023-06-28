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

            Position pos = new Position(0, 0);

            //North East
            pos.DefineValues(pos.Line - 1, pos.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column + 1;
            }
            //Southeast
            pos.DefineValues(pos.Line + 1, pos.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column + 1;
            }
            //South-West
            pos.DefineValues(pos.Line + 1, pos.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
                pos.Column = pos.Column - 1;
            }
            //Northwest
            pos.DefineValues(pos.Line - 1, pos.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
                pos.Column = pos.Column - 1;
            }

            return matrix;
        }
    }
}
