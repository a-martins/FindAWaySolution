using FindAWayProject.Models;

namespace FindAWayProject.Generators.Interfaces
{
    public interface IPathGenerator
    {
        PathModel GenerateAPath();

        GameDimensions GetDimensions();
    }
}