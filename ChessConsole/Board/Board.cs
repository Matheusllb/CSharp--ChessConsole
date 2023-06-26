namespace board
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool ExistingPiece(Position pos)
        {
            CheckPosition(pos);
            return piece(pos) != null;

        }

        public void AddPiece(Piece p, Position pos)
        {
            if (ExistingPiece(pos))
            {
                throw new BoardException("Já existe uma peça nessa posição"); //Already exist a piece in this position
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece pieceToBeRemoved = piece(pos);
            pieceToBeRemoved.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return pieceToBeRemoved;
        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void CheckPosition(Position pos)
        {
            if (!ValidPosition(pos)) 
            {
                throw new BoardException("Posição Inválida!"); //Invalid Position!
            }
        }
    }
}
