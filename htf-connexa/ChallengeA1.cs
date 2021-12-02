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

        public string startUrl { get; set; }
        public string sampleUrl { get; set; }
        public string puzzleUrl { get; set; }
        public List<int> PuzzleList { get; set; }
        public List<int> SampleList { get; set; }
        
        public ChallengeA1()
        {
            startUrl = "api/path/1/easy/Start";
            sampleUrl = "api/path/1/easy/Puzzle";
            sampleUrl = "api/path/1/easy/Sample";
        }

        public async Task SolvePuzzle(HttpClient client)
        {
            PuzzleList = await client.GetFromJsonAsync<List<int>>(sampleUrl);

            var puzzleAnswer = (int)GetAnswer();

            var puzzlePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, puzzleAnswer);
            var puzzlePostResponseValue = await puzzlePostResponse.Content.ReadAsStringAsync();

            Console.WriteLine("Puzzle response: " + puzzlePostResponseValue);
        }

        public async Task GetSampleData(HttpClient client)
        {
            SampleList = await client.GetFromJsonAsync<List<int>>(sampleUrl);

            foreach (int i in SampleList)
            {
                Console.WriteLine(SampleList.IndexOf(i) + " : " + i);
            }

        }

        public async Task SolveSample(HttpClient client)
        {
            var sampleGetResponse = await client.GetFromJsonAsync<List<int>>(sampleUrl);

            int sampleAnswer = (int)GetSampleAnswer();

            var samplePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, sampleAnswer);
            var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();


            Console.WriteLine("Puzzle response: " + samplePostResponseValue);
        }

        public object GetSampleAnswer()
        {
            bool moreThanOne = true;
            int som = 0;

            int[] data = SampleList.ToArray();

            while (moreThanOne)
            {
                foreach (int j in data)
                {
                    som += j;
                }
                Console.WriteLine("Tussengetal= " + som);
                char[] somString = som.ToString().ToCharArray();
                int[] newData = Array.ConvertAll(somString, c => (int)Char.GetNumericValue(c));

                if (newData.Count() == 1)
                {
                    moreThanOne = false;
                }

                data = newData;
                som = 0;
            }


            return som;
        }

        public async Task StartChallenge(HttpClient client)
        {
            var startResponse = await client.GetAsync(startUrl);
            Console.WriteLine("startResponse: " + startResponse);
        }

        public object GetAnswer()
        {
            foreach (int startD in PuzzleList)
            {
                Console.WriteLine(PuzzleList.IndexOf(startD) + " : " + startD);
            }
            bool moreThanOne = true;
            int som = 0;
            int[] data = PuzzleList.ToArray();

            while (moreThanOne)
            {
                foreach (int j in data)
                {
                    som += j;
                }
                Console.WriteLine("Tussengetal= " + som);
                char[] somString = som.ToString().ToCharArray();
                int[] newData = Array.ConvertAll(somString, c => (int)Char.GetNumericValue(c));

                data = newData;
                som = 0;
                if (newData.Count() == 1)
                {
                    moreThanOne = false;
                }

            }

            return data[0];
        }
    }
}
