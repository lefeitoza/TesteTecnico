using Newtonsoft.Json;
using Questao2.Model;

namespace Questao2.Client
{
    public class FootballMatchesApiClient
    {
        const string _baseUrl = "https://jsonmock.hackerrank.com/api/";
        const string _footballMatches = "football_matches";
        private ApiClient _apiClient = new();

        public FootballMatchesResponse GetByTeam1AndYear(string team, int year, int page = 1)
        {                        
            try
            {
                return JsonConvert.DeserializeObject<FootballMatchesResponse>(_apiClient.Execute(_baseUrl, string.Format("{0}?year={1}&team1={2}&page={3}", _footballMatches, year.ToString(), team, page)));
            }
            catch (Exception)
            {

                throw;
            }            
        }
        public FootballMatchesResponse GetByTeam2AndYear(string team, int year, int page = 1)
        {                        
            try
            {
                return JsonConvert.DeserializeObject<FootballMatchesResponse>(_apiClient.Execute(_baseUrl, string.Format("{0}?year={1}&team2={2}&page={3}", _footballMatches, year.ToString(), team, page)));
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
