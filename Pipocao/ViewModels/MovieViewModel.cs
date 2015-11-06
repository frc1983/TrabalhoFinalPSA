using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pipocao.ViewModels
{
    public class MovieViewModel
    {
        [Display(Name = "Possui Conteúdo Adulto?")]
        public bool adult { get; set; }

        public String backdrop_path { get; set; }

        public Int32 id { get; set; }

        [Display(Name = "Língua Original")]
        public String original_language { get; set; }

        [Display(Name = "Titulo Original")]
        public String original_title { get; set; }

        [Display(Name = "Sinopse")]
        public String overview { get; set; }

        [Display(Name = "Data de Lançamento")]
        public DateTime release_date { get; set; }

        public String poster_path { get; set; }

        [Display(Name = "Popularidade")]
        public double popularity { get; set; }

        [Display(Name = "Título")]
        public String title { get; set; }

        [Display(Name = "Possui Trailer?")]
        public bool video { get; set; }

        public double vote_average { get; set; }
        public Int32 vote_count { get; set; }

        [Display(Name = "Gêneros")]
        public List<String> genres { get; set; }

        public List<String> production_companies { get; set; }
        public List<String> production_countries { get; set; }
        public Int32 revenue { get; set; }
        public Int32 runtime { get; set; }
        public List<String> spoken_languages { get; set; }
        public String status { get; set; }
        public String tagline { get; set; }

        public bool IsVisible { get; set; }

        public MovieViewModel(TMDBService.Models.Movie movie)
        {
            this.adult = movie.adult;
            this.backdrop_path = movie.backdrop_path;
            this.id = movie.id;
            this.original_language = movie.original_language;
            this.original_title = movie.original_title;
            this.overview = movie.overview;
            this.release_date = movie.release_date;
            this.poster_path = movie.poster_path;
            this.popularity = movie.popularity;
            this.title = movie.title;
            this.video = movie.video;
            this.vote_average = movie.vote_average;
            this.vote_count = movie.vote_count;

            this.genres = new List<string>();
            foreach (var genre in movie.genres)
                this.genres.Add(genre.name);

            this.production_companies = new List<string>();
            foreach (var production_company in movie.production_companies)
                this.production_companies.Add(production_company.name);

            this.production_countries = new List<string>();
            foreach (var production_country in movie.production_countries)
                this.production_countries.Add(production_country.name);

            this.revenue = movie.revenue;
            this.runtime = movie.runtime;

            this.spoken_languages = new List<string>();
            foreach (var spoken_language in movie.spoken_languages)
                this.spoken_languages.Add(spoken_language.name);

            this.status = movie.status;
            this.tagline = movie.tagline;
            this.IsVisible = true;
        }
    }
}