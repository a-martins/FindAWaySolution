using System;
using System.Collections.Generic;

namespace FindAWayProject.Models
{
    public class PathModel
    {
        public Guid PathId { get; set; }
        public List<BlockPositionModel> BlockPositions { get; set; }

        public PathModel()
        {
            PathId = Guid.NewGuid();
            BlockPositions = new List<BlockPositionModel>();
        }
    }
}