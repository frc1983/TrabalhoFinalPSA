using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMDBService
{
    public interface IMovieService
    {
        //  http://api.themoviedb.org/3/discover/movie {&page}
        Task<List<Movie>> getMoviesAsync(String action, Dictionary<String, String> parameters);
        
        //  http://api.themoviedb.org/3/movie/{id}
        Task<Movie> getMovieAsync(String action, Dictionary<String, String> parameters);

        //  http://api.themoviedb.org/3/movie/{id}/images
        Task<List<Movie>> getMovieImagesAsync(String action, Dictionary<String, String> parameters);

        //  http://api.themoviedb.org/3/movie/{id}/credits
        Task<List<Movie>> getMovieCreditsAsync(String action, Dictionary<String, String> parameters);

        //  http://api.themoviedb.org/3/genre/movie/list
        Task<List<Genre>> getGenresAsync();
    }
}