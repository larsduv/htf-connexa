using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace htf_connexa
{
    class ChallangeB1 : IChallenge
    {
        public HttpClient Client { get; set; }
        public string startUrl { get ; set ; }
        public string sampleUrl { get; set; }
        public string puzzleUrl { get ; set ; }

        public ChallangeB1(HttpClient _client)
        {
            this.Client = _client;
            this.startUrl = "api/path/2/easy/Start";
            this.sampleUrl = "api/path/2/easy/Sample";
            this.puzzleUrl = "api/path/2/easy/Puzzle";
        }

        public async Task StartChallenge(HttpClient client)
        {
            var startResponse = await client.GetAsync(this.startUrl);
            Console.WriteLine($"{startResponse} start");
        }

        public async Task<string> GetPuzzle(HttpClient client)
        {
            var puzzleGetResponse = await client.GetFromJsonAsync<ChallangeB1Model>(puzzleUrl);

            string formatedDate1 = changeFormatDate(puzzleGetResponse.Date1);
            string formatedDate2 = changeFormatDate(puzzleGetResponse.Date2);

            DateTime parsedDate1 = parseDate(formatedDate1);
            DateTime parsedDate2 = parseDate(formatedDate2);;

            return Math.Abs((parsedDate1 - parsedDate2).TotalSeconds).ToString();
        }

        string changeFormatDate(string date)
        {
            int second = date.IndexOf('s');
            int minute = date.IndexOf('m');
            int hour = date.IndexOf('h');
            int day = date.IndexOf('D');
            int month = date.IndexOf('M');
            int year = date.IndexOf('Y');

            string secondString = date.Substring(second - 2, 2);
            string minutString = date.Substring(minute - 2, 2);
            string hourString = date.Substring(hour - 2, 2);
            string dayString = date.Substring(day - 2, 2);
            string monthString = date.Substring(month - 2, 2);
            string yearString = date.Substring(year - 4, 4);

            return yearString + "-" + monthString + "-" + dayString + " " + hourString + ":" + minutString + ":" + secondString;
        }

        DateTime parseDate(string date)
        {
            return DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", null);
        }

        public async Task SolvePuzzle(HttpClient client)
        {
            var puzzleAnswer = await GetPuzzle(client);
            var postPuzzleResponse = await client.PostAsJsonAsync<string>(puzzleUrl, puzzleAnswer);
            
            var puzzlePostResponseValue = await postPuzzleResponse.Content.ReadAsStringAsync();
            Console.WriteLine(puzzlePostResponseValue);
        }




    }
}
