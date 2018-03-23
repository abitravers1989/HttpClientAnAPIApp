using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using HttpPracticeConsoleApp;


namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProcessRepositories().Wait();
            Console.ReadKey();

        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));


            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;

            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
            }
            
        }
    }
}
