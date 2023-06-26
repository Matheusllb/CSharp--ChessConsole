namespace board
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
    }
}
