using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace htf_connexa
{
    public class ChallengeA1 : IChallenge
    {
        private HttpResponseMessage samplePostResponse;

        public string startUrl { get; set; }
        public string puzzleUrl { get; set; }
        public string sampleUrl { get; set; }

        public ChallengeA1()
        {
        }

        public async Task SolvePuzzle(HttpClient client, string puzzleUrl)
        {
            var puzzleGetResponse = await client.GetFromJsonAsync<List<int>>(puzzleUrl);

            var puzzleAnswer = GetAnswer(puzzleGetResponse);

            var puzzlePostResponse = await client.PostAsJsonAsync<int>(puzzleUrl, puzzleAnswer);
            var puzzlePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
        }

        public Task SolveSample(HttpClient client, string sampleUrl)
        {
            throw new NotImplementedException();
        }

        public Task StartChallenge(HttpClient client, string startUrl)
        {
            throw new NotImplementedException();
        }

        public object GetAnswer(object puzzleGetResponse)
        {
            int number = 1;
            return number;
        }
    }
}
