﻿using System;
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
            var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


        }

        private static async Task StartChallenge(HttpClient client, string startUrl)
        {
            var startResponse = await client.GetAsync(startUrl);
        }

        private static async Task SolvePuzzle(HttpClient client, string puzzleUrl)
        {
            var puzzleGetResponse = await client.GetFromJsonAsync<List<int>>(puzzleUrl);

            var puzzleAnswer = GetAnswer(puzzleGetResponse);

            var puzzlePostResponse = await client.PostAsJsonAsync<int>(puzzleUrl, puzzleAnswer);
            var puzzlePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
        }

        private static async Task SolveSample(HttpClient client)
        {
            
        }

        private static object GetAnswer(object puzzleGetResponse)
        {
            throw new NotImplementedException();
        }
    }
}
