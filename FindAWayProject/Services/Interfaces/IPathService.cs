using FindAWayProject.Models;
using System;
using System.Collections.Generic;

namespace FindAWayProject.Services.Interfaces
{
    public interface IPathService
    {
        List<PathModel> GetAllPath();

        PathModel GetPathById(Guid guid);

        GameDimensions GeneratePath();

        void SavePath(PathModel path);

        BlockModel GetBlock(int col, int lin, Guid guid);

        List<BlockPositionModel> GetFullPath(Guid guid);
    }
}