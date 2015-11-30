using Business.Exceptions;
using DAL;
using Entities;
using Pipocao.DAL;
using System;
using System.Collections.Generic;
using TMDBService;

namespace Business
{
    public class MovieBusiness
    {
        public List<Movie> List(int page)
        {
            List<Movie> movies = new List<Movie>();
            var list = new MovieRepository().List(page);
            if (list == null)
                throw new MovieBusinessException("Nenhum filme encontrado.");

            return list;
        }

        public Movie GetById(int id)
        {
            return MovieServiceFacade.Instance.GetById(id);
        }

        public void InsertMovie(Int32 movieId, String login)
        {
            MovieRepository movieRepository = new MovieRepository();

            var user = new UserRepository().FindByEmail(login);
            if (user == null)
                throw new UserBusinessException("Usuário não cadastrado.");

            var userMovies = movieRepository.ListFromUser(user);
            foreach(var movie in userMovies)
                if(movie.id == movieId)
                    throw new MovieBusinessException("Filme já cadastrado na sua coleção.");

            movieRepository.InsertMovie(movieId, user);
        }

        public List<Movie> ListFromUser(string login)
        {
            var user = new UserRepository().FindByEmail(login);
            if (user == null)
                throw new MovieBusinessException("Usuário não cadastrado.");

            var userMovies = new MovieRepository().ListFromUser(user);
            if (userMovies == null)
                throw new MovieBusinessException("Nenhum filme cadastrado na sua coleção.");

            return userMovies;
        }

        public List<Movie> GetTopTenBestMovies()
        {
            return new MovieRepository().GetTopTenBestMovies();
        }

        public List<Movie> GetTopTenWorstMovies()
        {
            return new MovieRepository().GetTopTenWorstMovies();
        }

        public void RemoveMovie(int id, string login)
        {
            MovieRepository movieRepository = new MovieRepository();

            var user = new UserRepository().FindByEmail(login);
            if (user == null)
                throw new UserBusinessException("Usuário não cadastrado.");

            movieRepository.RemoveMovieFromUser(id, user);
        }
    }
}
