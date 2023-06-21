﻿using Board;

namespace ChessConsole.Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int Moves { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Position position, Board bord, Color color)
        {
            Position = position;
            Board = bord;
            Color = color;
            Moves = 0;
        }
    }
}