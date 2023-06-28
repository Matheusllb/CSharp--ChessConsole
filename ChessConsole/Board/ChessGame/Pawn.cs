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

        private bool HasEnemy(Position pos)
        {
            Piece piece = Board.piece(pos);
            return piece != null && piece.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.piece(pos) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(Position.Line, Position.Column);

            if(Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && Moves == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && HasEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && HasEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && Moves == 0)
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && HasEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && HasEnemy(pos))
                {
                    matrix[pos.Line, pos.Column] = true;
                }
            }

            return matrix;
        }
    }
}
