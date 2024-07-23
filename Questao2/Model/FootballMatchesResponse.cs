using Newtonsoft.Json;

namespace Questao2.Model
{
    public class FootballMatchesResponse
    {
        public int Page { get; set; }
        [JsonProperty("per_page")]
        public int ItemsPerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages{get; set;}

        [JsonProperty("data")]
        public List<MatcheData> MatcheData { get; set; }
    }

    public class MatcheData
    {
        public string Competition { get; set; }

        public int Year { get; set; }
        public string Round { get; set; }

        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }

    }
}
