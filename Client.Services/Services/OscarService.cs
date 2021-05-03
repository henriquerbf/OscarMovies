using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Oscar.Domain.Interfaces;
using Oscar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client.Services
{
    public class DataObject
    {
        public string Name { get; set; }
    }

    public class OscarService : IOscarService
    {
        private readonly IConfiguration _configuration;

        public  OscarService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            HttpClient client = NewHttpClient();

            Movie responseObject;

            // List data response.
            HttpResponseMessage response = client.GetAsync($"/Movies/Select/{id}").Result;
            // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var responseString = await response.Content.ReadAsStringAsync();
                responseObject = JsonConvert.DeserializeObject<Movie>(responseString);
            }
            else
                responseObject = new Movie();

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();

            return await Task.FromResult<Movie>(responseObject);
        }

        private HttpClient NewHttpClient()
        {
            var URL = _configuration.GetSection("url").GetSection("Oscar_Api").Value;

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public async Task<Movie> InsertMovie(Movie movie)
        {
            HttpClient client = NewHttpClient();

            Movie responseObject;

            List<JsonMovies> jsonMovies = new List<JsonMovies>()
            {
                new JsonMovies
                {
                    Id = movie.Id_Received,
                    Title = movie.Title,
                    Release_Date = movie.Release_Date,
                }
            };

            // List data response.
            //HttpResponseMessage response = client.PostAsJsonAsync<List<Movie>>($"/Movies/Insert", new List<Movie> { movie }).Result;
            HttpResponseMessage response = client.PostAsJsonAsync<List<JsonMovies>>($"/Movies/Insert", jsonMovies).Result;
            
            // Blocking call! Program will wait here until a response is received or a timeout occurs.

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var responseString = await response.Content.ReadAsStringAsync();
                responseObject = JsonConvert.DeserializeObject<Movie>(responseString);
            }
            else
                responseObject = new Movie();

            client.Dispose();

            return await Task.FromResult<Movie>(responseObject);
        }

    }
}
