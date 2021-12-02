using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace htf_connexa
{
    public class ChallengeA2 //: IChallenge
    {
        public string startUrl { get; set; }
        public string sampleUrl { get; set; }
        public string puzzleUrl { get; set; }

        public int sampleStartFloor;
        public int sampleDestFloor;
        public int puzzleStartFloor;
        public int puzzleDestFloor;

        public ChallengeA2()
        {
            startUrl = "api/path/1/medium/Start";
            sampleUrl = "api/path/1/medium/Puzzle";
            puzzleUrl = "api/path/1/medium/Sample";
        }
        //public object GetAnswer()
        //{
        //}

        //public object GetSampleAnswer()
        //{
        //}

        public async Task SolvePuzzle(HttpClient client)
        {
            ChallengeA2Model data = await client.GetFromJsonAsync<ChallengeA2Model>(puzzleUrl);
            puzzleStartFloor = data.start;
            puzzleDestFloor = data.destination;

            //int[] puzzleAnswer = (int[])GetAnswer();

           // var puzzlePostResponse = await client.PostAsJsonAsync<int[]>(puzzleUrl, puzzleAnswer);
           // var puzzlePostResponseValue = await puzzlePostResponse.Content.ReadAsStringAsync();

           // Console.WriteLine("Puzzle response: " + puzzlePostResponseValue);
        }

        public async Task GetSampleData(HttpClient client)
        {
            ChallengeA2Model data = await client.GetFromJsonAsync<ChallengeA2Model>(sampleUrl);

            Console.WriteLine("start: " + data.start);
            Console.WriteLine("desti: " + data.destination);
        }
        public async Task GetPuzzleData(HttpClient client)
        {
            ChallengeA2Model data = await client.GetFromJsonAsync<ChallengeA2Model>(puzzleUrl);

            Console.WriteLine("start: " + data.start);
            Console.WriteLine("desti: " + data.destination);
        }


        public async Task SolveSample(HttpClient client)
        {

            ChallengeA2Model data = await client.GetFromJsonAsync<ChallengeA2Model>(sampleUrl);
            sampleStartFloor = data.start;
            sampleDestFloor = data.destination;

            List<int> sampleAnswer = (List<int>)GetSampleAnswer();

            //var samplePostResponse = await client.PostAsJsonAsync<List<int>>(sampleUrl, sampleAnswer);
            //var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();

            //Console.WriteLine("Sample response: " + samplePostResponseValue);
        }

        private List<int> GetSampleAnswer()
        {
            List<int> floors = new List<int>();

            floors.Add(sampleStartFloor);

            int currentFloor = sampleStartFloor;
            int lastFloor = sampleStartFloor;
            int counter = 1;
            int diffCurrent = currentFloor - sampleDestFloor;
            int diffLast = diffCurrent + 1;

            while (currentFloor != sampleDestFloor)
            {

                diffCurrent = currentFloor - sampleDestFloor;
                diffLast = lastFloor - sampleDestFloor;
                if (diffCurrent < diffLast)
                {
                    // dichterbij uitkomst
                    if (currentFloor < sampleDestFloor)
                    {
                        currentFloor += counter;
                    }
                    else if(currentFloor > sampleDestFloor)
                    {
                        currentFloor -= counter;
                    }
                }
                else if (diffCurrent > diffLast)
                {
                    // verder van uitkomst
                    floors.Remove(counter);
                    counter--;
                    if (lastFloor < sampleDestFloor)
                    {
                        lastFloor += counter;
                    }
                    if (lastFloor > sampleDestFloor)
                    {
                        lastFloor -= counter;
                    }
                    currentFloor = lastFloor;
                }
                else if (diffCurrent == diffLast)
                {
                    currentFloor += counter;
                }
                
                if (currentFloor == sampleDestFloor)
                {
                    floors.Add(sampleDestFloor);
                }

                lastFloor = currentFloor;
                Console.WriteLine(currentFloor);
                counter++;

            }

            return floors;
        }

        public async Task StartChallenge(HttpClient client)
        {
            var startResponse = await client.GetAsync(startUrl);
            Console.WriteLine("startResponse: " + startResponse);
        }
    }
}
