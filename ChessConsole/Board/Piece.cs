﻿namespace board
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board bord, Color color)
        {
            Position = null;
            Board = bord;
            Color = color;
            Moves = 0;
        }

        public void IncrementsMoves()
        {
            Moves++;
        }

        public bool ExistPossibleMoves()
        {
            bool[,] matrix = PossibleMoves();
            for(int i = 0; i < Board.Lines; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i,j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract bool[,] PossibleMoves();
    }
}
