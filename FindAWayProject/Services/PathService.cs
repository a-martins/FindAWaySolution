using FindAWayProject.Generators.Interfaces;
using FindAWayProject.Models;
using FindAWayProject.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FindAWayProject.Services
{
    public class PathService : IPathService
    {
        private IPathGenerator _pathGenerator;

        public PathService(IPathGenerator pathGenerator)
        {
            _pathGenerator = pathGenerator ?? throw new ArgumentNullException(nameof(pathGenerator));
        }

        public GameDimensions GeneratePath()
        {
            var viewPath = _pathGenerator.GetDimensions();

            var path = _pathGenerator.GenerateAPath();

            SavePath(path);

            viewPath.PathId = path.PathId;
            return viewPath;
        }

        public List<PathModel> GetAllPath()
        {
            List<PathModel> searchResults = new List<PathModel>();

            if (File.Exists(@"wwwroot/json/paths.json"))
            {
                using (StreamReader sw = new StreamReader(@"wwwroot/json/paths.json"))
                {
                    using (MemoryStream stream = new MemoryStream(
                    Encoding.UTF8.GetBytes(sw.ReadToEnd())))
                    {
                        DataContractJsonSerializer serializer =
                            new DataContractJsonSerializer(typeof(List<PathModel>));

                        searchResults = (List<PathModel>)serializer.ReadObject(stream);
                    }
                }
            }

            return searchResults;
        }

        public BlockModel GetBlock(int column, int line, Guid guid)
        {
            var path = GetPathById(guid);

            var block = path.BlockPositions.Where(x =>
                x.ColumnNumber == column &&
                x.LineNumber == line
            ).FirstOrDefault().Block;

            return block;
        }

        public List<BlockPositionModel> GetFullPath(Guid guid)
        {
            var path = GetPathById(guid);

            var block = path.BlockPositions.Where(x =>
                x.Block.IsCorrect
            ).ToList();

            return block;
        }

        public PathModel GetPathById(Guid guid)
        {
            var list = GetAllPath();

            return list.Where(x => x.PathId == guid).FirstOrDefault();
        }

        public void SavePath(PathModel path)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            List<PathModel> pathList = GetAllPath();
            pathList.Add(path);

            using (StreamWriter sw = new StreamWriter(@"wwwroot/json/paths.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, pathList);
            }
        }
    }
}