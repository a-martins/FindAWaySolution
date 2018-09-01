using System;

namespace FindAWayProject.Models
{
    public class GameDimensions
    {
        public Guid PathId { get; set; }
        public int ColumnsDimension { get; set; }
        public int LinesDimension { get; set; }

        public GameDimensions(int columns, int lines)
        {
            ColumnsDimension = columns;
            LinesDimension = lines;
        }
    }
}