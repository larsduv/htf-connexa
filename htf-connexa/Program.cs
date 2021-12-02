using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace htf_connexa
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Connect code
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");

            var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNDYiLCJuYmYiOjE2Mzg0MzU1NDQsImV4cCI6MTYzODUyMTk0NCwiaWF0IjoxNjM4NDM1NTQ0fQ.ZgPbPuSDgkFOeiqzajpWruAOrlh258x3k-Lh9PvNIk4zfGQ6ZC2gV8da2TKoYpU4RtADmMIwRv_tJjqyA3vwDg";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            ChallengeA1 a1 = new ChallengeA1();
            //await a1.StartChallenge(client);


            //await a1.SolvePuzzle(client);

            ChallengeA2 a2 = new ChallengeA2();
            await a2.StartChallenge(client);
            await a2.GetSampleData(client);
            await a2.SolveSample(client);
            //await a2.GetPuzzleData(client);

            await a1.SolvePuzzle(client);
          
            //B1
            ChallangeB1 b1 = new ChallangeB1(client);
            await b1.StartChallenge(client);
            await b1.SolvePuzzle(client);

            Console.ReadLine();
        }
    }
}
