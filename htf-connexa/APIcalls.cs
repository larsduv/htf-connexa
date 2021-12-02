using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;

namespace htf_connexa
{
    public class APIcalls
    {
        //Swagger 
        // https://involved-htf-challenge.azurewebsites.net/swagger/index.html

        HttpClient client;

        public APIcalls(HttpClient client)
        {
            this.client = client;
            client.BaseAddress = new Uri("https://involved-htf-challenge.azurewebsites.net/");

        }

        public async void ()
        {
            var client = new HttpClient();
         
            client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");

            var token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var startUrl = "api/path/1/easy/Start";
            var startResponse = await client.GetAsync(startUrl);

            var puzzleUrl = "api/path/1/easy/Puzzle";
            var puzzleGetResponse = await client.GetFromJsonAsync<List<int>>(puzzleUrl);

            var puzzleAnswer = GetAnswer(puzzleGetResponse);

            var puzzlePostResponse = await client.PostAsJsonAsync<int>(sampleUrl, puzzleAnswer);
            var puzzlePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
        }
    }
}
