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

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(Position.Line, Position.Column);

            //up
            pos.DefineValues(pos.Line - 1, pos.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            //Down
            pos.DefineValues(pos.Line + 1, pos.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            //Right
            pos.DefineValues(pos.Line, pos.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            //Left
            pos.DefineValues(pos.Line, pos.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            //North East
            pos.DefineValues(pos.Line - 1, pos.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line -= 1, pos.Column += 1);

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
                pos.DefineValues(pos.Line += 1, pos.Column += 1);

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
                pos.DefineValues(pos.Line += 1, pos.Column -= 1);

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
                pos.DefineValues(pos.Line -= 1, pos.Column -= 1);

            }

            return matrix;
        }
    }
}
