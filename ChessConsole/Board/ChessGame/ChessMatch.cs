using board;

namespace ChessGame
{
    public class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn;
        private Color ActualPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            PutPieces();
        }

        public void ExecuteMoviment(Position origin, Position destination)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncrementsMoves();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.AddPiece(p, destination);
            
        }

        private void PutPieces()
        {
            //Blacks
            Board.AddPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());
            Board.AddPiece(new Queen(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.Black), new ChessPosition('f', 8).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.AddPiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).ToPosition());
            Board.AddPiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).ToPosition());
            Board.AddPiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).ToPosition());
            Board.AddPiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('a', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('b', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('f', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('g', 7).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.Black), new ChessPosition('h', 7).ToPosition());
            //Whites
            Board.AddPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());
            Board.AddPiece(new Queen(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).ToPosition());
            Board.AddPiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.AddPiece(new Knight(Board, Color.White), new ChessPosition('b', 1).ToPosition());
            Board.AddPiece(new Knight(Board, Color.White), new ChessPosition('g', 1).ToPosition());
            Board.AddPiece(new Rook(Board, Color.White), new ChessPosition('h', 1).ToPosition());
            Board.AddPiece(new Rook(Board, Color.White), new ChessPosition('a', 1).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).ToPosition());
            Board.AddPiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).ToPosition());
        }
    }
}
