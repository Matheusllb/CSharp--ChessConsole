using board;

namespace ChessGame
{
    public class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }


        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public Piece ExecuteMoviment(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementsMoves();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(p, destination);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMoviment(Position origin, Position des, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(des);
            p.DecrementsMoves();
            if(capturedPiece != null)
            {
                Board.AddPiece(capturedPiece, des);
                Captured.Remove(capturedPiece);
            }
            Board.AddPiece(p, origin);
        }

        public void PerformPlay(Position origin, Position destination)
        {
            Piece capturedPiece = ExecuteMoviment(origin, destination);

            if (InCheck(ActualPlayer))
            {
                UndoMoviment(origin, destination, capturedPiece);
                throw new BoardException("Você não pode se colocar em Xeque!");
            }
            if (InCheck(Adversary(ActualPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckMate(Adversary(ActualPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
        }

        public void ChangePlayer()
        {
            if (ActualPlayer == Color.White)
            {
                ActualPlayer = Color.Black;
            }
            else
            {
                ActualPlayer = Color.White;
            }
        }

        public string TranslateColor(Color color)
        {
            switch (color)
            {
                case Color.White:
                    return "Branco";
                case Color.Black:
                    return "Preto";
                default:
                    return color.ToString();
            }
        }

        public void CheckOriginPosition(Position pos)
        {
            if(Board.piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição escolhida!");
            }
            if(ActualPlayer != Board.piece(pos).Color)
            {
                throw new BoardException("Você não pode mover a peça do oponente!");
            }
            if (!Board.piece(pos).ExistPossibleMoves())
            {
                throw new BoardException("A peça escolhida não pode ser movida");
            }
        }
        public void CheckDestinationPosition(Position origin, Position des)
        {
            if (!Board.piece(origin).PossibleMoviment(des))
            {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        public void PutNewPiece(char column, int line, Piece p)
        {
            Board.AddPiece(p, new ChessPosition(column, line).ToPosition());
            Pieces.Add(p);
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Adversary(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece x in PiecesInGame(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool InCheck(Color color)
        {
            Piece r = King(color);
            /*if (r == null)
            {
                throw new BoardException("Não tem Rei da cor " + TranslateColor(color) + " presente no tabuleiro!");
            }*/

            foreach(Piece x in PiecesInGame(Adversary(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[r.Position.Line,r.Position.Column]) 
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckMate(Color color)
        {
            if (!InCheck(color))
            {
                return false;
            }
            else
            {
                foreach(Piece x in PiecesInGame(color))
                {
                    bool[,] mat = x.PossibleMoves();
                    for(int i = 0; i < Board.Lines; i++)
                    {
                        for(int j = 0; j < Board.Columns; j++)
                        {
                            if (mat[i, j])
                            {
                                Position origin = x.Position;
                                Position destination = new Position(i, j);
                                Piece capturedPiece = ExecuteMoviment(origin, destination);
                                bool checkTest = InCheck(color);
                                UndoMoviment(origin, destination, capturedPiece);
                                if (!checkTest) 
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            }
        }

        private void PutPieces()
        {
            //Blacks
            PutNewPiece('d', 8, new King(Board, Color.Black));
            PutNewPiece('e', 8, new Queen(Board, Color.Black));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('b', 8, new Knight(Board, Color.Black));
            PutNewPiece('g', 8, new Knight(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black));
            //Whites
            PutNewPiece('d', 1, new King(Board, Color.White));
            PutNewPiece('e', 1, new Queen(Board, Color.White));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('b', 1, new Knight(Board, Color.White));
            PutNewPiece('g', 1, new Knight(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White));
            PutNewPiece('b', 2, new Pawn(Board, Color.White));
            PutNewPiece('c', 2, new Pawn(Board, Color.White));
            PutNewPiece('d', 2, new Pawn(Board, Color.White));
            PutNewPiece('e', 2, new Pawn(Board, Color.White));
            PutNewPiece('f', 2, new Pawn(Board, Color.White));
            PutNewPiece('g', 2, new Pawn(Board, Color.White));
            PutNewPiece('h', 2, new Pawn(Board, Color.White));
        }
    }
}

