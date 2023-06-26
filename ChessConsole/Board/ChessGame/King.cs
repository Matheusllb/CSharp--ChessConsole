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

        private bool CanMove(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != this.Color;
        }

        override public abstract bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //Up
            pos.DefineValues(Position.Line - 1, Position.Column);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //North East
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //Right
            pos.DefineValues(Position.Line, Position.Column + 1);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //Southeast
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //Down
            pos.DefineValues(Position.Line + 1, Position.Column);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //South-West
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //Left
            pos.DefineValues(Position.Line, Position.Column - 1);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }
            //Northwest
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                matrix[pos.Line, pos.Column] = true;
            }

            return matrix;
        }

    }
}
