using System.Text.Json.Serialization;

namespace GameFinder.Model
{
    public class GameModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Round { get; set; }
        public string Team { get; set; }
        public string Player { get; set; }
        public int Score { get; set; }
        public int Stats { get; set; }
    }

    [JsonSerializable(typeof(List<GameModel>))]
    internal sealed partial class GameContext : JsonSerializerContext
    {

    }


}
