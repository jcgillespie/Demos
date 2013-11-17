namespace DudeDemo
{
    using System.Collections.Generic;

    public class ChessBoard2
    {
        public List<Square2> Squares;

        public ChessBoard2()
        {
            this.Squares = new List<Square2>(16);
        }

        public List<Square2> GetOccupiedSquares()
        {
            var occupied = new List<Square2>();
            foreach (var square in this.Squares)
            {
                if (square.Status == Square2.OccupiedStatus)
                {
                    occupied.Add(square);
                }
            }

            return occupied;
        }
    }

    public class Square2
    {
        public const int EmptyStatus = 0;
        public const int OccupiedStatus = 1;

        public Square2(int x, int y, int status)
        {
            this.XCoord = x;
            this.YCoord = y;
            this.Status = status;
        }

        public int Status { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }
    }
}