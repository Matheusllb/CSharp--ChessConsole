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

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != this.Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(Position.Line, Position.Column);

            //RightUpOne
            pos.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //RightUpTwo
            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //RightDownOne
            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //RightDownTwo
            pos.DefineValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //LeftDownOne
            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //LeftDownTwo
            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //LeftUpTwo
            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //LeftUpOne
            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            return matrix;
        }
    }
}
