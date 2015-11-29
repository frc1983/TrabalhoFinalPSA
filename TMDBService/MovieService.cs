using Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TMDBService
{
    public class MovieService : IMovieService
    {
        private static String baseURL = "http://api.themoviedb.org/3/";
        private static String apiKey = "?api_key=8f4b1268f33c809c1aac120b6530de90&language=pt";

        public async Task<List<Movie>> getMoviesAsync(string action, Dictionary<string, string> parameters)
        {
            List<Movie> retorno = null;

            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(baseURL);

                String param = parseParameters(parameters);
                HttpResponseMessage response = client.GetAsync(action + apiKey + param).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsAsync<MovieResult>();
                    var genres = await getGenresAsync();
                    foreach (Movie movie in jsonString.results)
                        foreach (Int32 genre_id in movie.genre_ids)
                            foreach (Genre genre in genres)
                                if (genre_id == genre.id)
                                    movie.genres.Add(genre);
                    
                    retorno = jsonString.results;
                }
            }
            catch (Exception e)
            {
                throw new ServiceException();
            }

            return retorno;
        }

        public async Task<Movie> getMovieAsync(string action, Dictionary<string, string> parameters)
        {
            Movie retorno = null;

            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(baseURL);

                String param = parseParameters(parameters);
                HttpResponseMessage response = client.GetAsync(action + apiKey + param).Result;
                if (response.IsSuccessStatusCode)
                    retorno = await response.Content.ReadAsAsync<Movie>();
            }
            catch (Exception e)
            {
                throw new ServiceException();
            }

            return retorno;
        }

        public async Task<List<Genre>> getGenresAsync()
        {
            List<Genre> retorno = null;

            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(baseURL);

                HttpResponseMessage response = client.GetAsync("genre/movie/list" + apiKey).Result;
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsAsync<GenreResult>();
                    retorno = jsonString.genres;
                }
            }
            catch (Exception e)
            {
                throw new ServiceException();
            }

            return retorno;
        }

        private string parseParameters(Dictionary<string, string> parameters)
        {
            String retorno = String.Empty;
            foreach (KeyValuePair<string, string> value in parameters)
            {
                retorno += "&" + value.Key + "=" + value.Value;
            }

            return retorno;
        }
    }
}