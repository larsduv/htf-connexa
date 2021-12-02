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
            var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiNDYiLCJuYmYiOjE2Mzg0NDA1MjgsImV4cCI6MTYzODUyNjkyOCwiaWF0IjoxNjM4NDQwNTI4fQ.jtyWL_hCsex0srI9LpD8AR0GDm7sxCPdiDybLZGXilYiSzXlNS0c4IxAyWxb9HRoe_rjbsfJpWusakm894tOQg";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            ChallengeA1 a1 = new ChallengeA1();
            //await a1.StartChallenge(client);

            //await a1.SolvePuzzle(client);

            ChallengeA2 a2 = new ChallengeA2();
            await a2.StartChallenge(client);
            await a2.GetSampleData(client);
            await a2.SolveSample(client);
            //await a2.GetPuzzleData(client);

            Console.ReadLine();
        }
    }
}
