using FindAWayProject.Strategies.Interfaces;

namespace FindAWayProject.Strategies
{
    public class NormalLevel : ILevel
    {
        private const int Lines = 5;
        private const int Columns = 4;

        public int GetNumberOfColumns()
        {
            return Columns;
        }

        public int GetNumberOfLines()
        {
            return Lines;
        }
    }
}