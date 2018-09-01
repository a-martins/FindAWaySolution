using System.Runtime.Serialization;

namespace FindAWayProject.Models
{
    [DataContract(Name = "Block")]
    public class BlockModel
    {
        [DataMember(Name = "IsCorrect")]
        public bool IsCorrect { get; set; }
    }
}