using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace htf_connexa
{
    public interface IChallenge
    {
        public Task StartChallenge(HttpClient client);
        //public Task SolveSample(HttpClient client);
        //public Task SolvePuzzle(HttpClient client);
        public string startUrl { get; set; }
        public string puzzleUrl { get; set; }
        public string sampleUrl { get; set; }
    }
}
