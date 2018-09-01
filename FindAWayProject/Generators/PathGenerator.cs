using FindAWayProject.Generators.Interfaces;
using FindAWayProject.Models;
using FindAWayProject.Strategies.Interfaces;
using System;

namespace FindAWayProject.Generators
{
    public class PathGenerator : IPathGenerator
    {
        private ILevel _level;
        private int _columnsDimensions { get; }
        private int _linesDimensions { get; }

        public PathGenerator(ILevel level)
        {
            _level = level ?? throw new ArgumentNullException(nameof(level));
            _columnsDimensions = level.GetNumberOfColumns();
            _linesDimensions = level.GetNumberOfLines();
        }

        public PathModel GenerateAPath()
        {
            var rnd = new Random();
            var path = new PathModel();

            var initialPosition = 1;
            var finalPosition = _columnsDimensions + 1;

            for (int lin = 1; lin <= _linesDimensions; lin++)
            {
                var correctBlock = rnd.Next(initialPosition, finalPosition);

                for (int col = 1; col <= _columnsDimensions; col++)
                {
                    var block = new BlockModel();
                    var blockPosition = new BlockPositionModel(lin, col);

                    if (col == correctBlock)
                    {
                        block.IsCorrect = true;
                    }
                    else
                    {
                        block.IsCorrect = false;
                    }

                    blockPosition.Block = block;
                    path.BlockPositions.Add(blockPosition);
                }

                initialPosition = correctBlock == 1 ? 1 : correctBlock - 1;
                finalPosition = correctBlock == _columnsDimensions ?
                    _columnsDimensions + 1 : correctBlock + 2;
            }
            return path;
        }

        public GameDimensions GetDimensions()
        {
            return new GameDimensions(_columnsDimensions, _linesDimensions);
        }
    }
}