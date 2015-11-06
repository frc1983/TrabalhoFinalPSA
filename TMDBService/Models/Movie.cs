using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMDBService.Models
{
    public class MovieResult
    {
        public String page { get; set; }
        public List<Movie> results { get; set; }
        public Int32 total_pages { get; set; }
        public Int32 total_results { get; set; }
    }

    public class Movie
    {
        private static String imageBaseURL = "http://image.tmdb.org/t/p/";
        private static String backdropImageSize = "w300";
        private static String posterImageSize = "w185";

        public bool adult { get; set; }

        public String _backdrop_path;
        public String backdrop_path
        {
            get { return this._backdrop_path; }
            set
            {
                if (value != null)
                    this._backdrop_path = imageBaseURL + backdropImageSize + value;
            }
        }

        public List<Int32> genre_ids { get; set; }
        public Int32 id { get; set; }

        public String original_language { get; set; }

        public String original_title { get; set; }

        public String overview { get; set; }

        public DateTime release_date { get; set; }

        public String _poster_path;
        public String poster_path
        {
            get { return this._poster_path; }
            set
            {
                if (value != null)
                    this._poster_path = imageBaseURL + posterImageSize + value;
            }
        }

        public double popularity { get; set; }

        public String title { get; set; }

        public bool video { get; set; }

        public double vote_average { get; set; }
        public Int32 vote_count { get; set; }

        private List<Genre> _genres;
        public List<Genre> genres
        {
            get
            {
                if (this._genres == null)
                    this._genres = new List<Genre>();

                return this._genres;
            }
            set { }
        }

        private List<ProductionCompanies> _production_companies;
        public List<ProductionCompanies> production_companies
        {
            get
            {
                if (this._production_companies == null)
                    this._production_companies = new List<ProductionCompanies>();

                return this._production_companies;
            }
            set { }
        }

        private List<ProductionCountries> _production_countries;
        public List<ProductionCountries> production_countries
        {
            get
            {
                if (this._production_countries == null)
                    this._production_countries = new List<ProductionCountries>();

                return this._production_countries;
            }
            set { }
        }

        public Int32 revenue { get; set; }
        public Int32 runtime { get; set; }

        private List<SpokenLanguages> _spoken_languages;
        public List<SpokenLanguages> spoken_languages
        {
            get
            {
                if (this._spoken_languages == null)
                    this._spoken_languages = new List<SpokenLanguages>();

                return this._spoken_languages;
            }
            set { }
        }

        public String status { get; set; }
        public String tagline { get; set; }
    }

    public class ProductionCompanies
    {
        public Int32 id { get; set; }
        public String name { get; set; }
    }

    public class ProductionCountries
    {
        public String iso_3166_1 { get; set; }
        public String name { get; set; }
    }

    public class SpokenLanguages
    {
        public String iso_639_1 { get; set; }
        public String name { get; set; }
    }
}