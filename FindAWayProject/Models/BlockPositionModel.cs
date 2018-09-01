using System.Runtime.Serialization;

namespace FindAWayProject.Models
{
    [DataContract(Name = "BlockPositions")]
    public class BlockPositionModel
    {
        [DataMember(Name = "LineNumber")]
        public int LineNumber { get; set; }

        [DataMember(Name = "ColumnNumber")]
        public int ColumnNumber { get; set; }

        [DataMember(Name = "Block")]
        public BlockModel Block { get; set; }

        public BlockPositionModel(int line, int column)
        {
            LineNumber = line;
            ColumnNumber = column;
        }
    }
}