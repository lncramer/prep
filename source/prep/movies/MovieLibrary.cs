using System;
using System.Collections.Generic;
using System.Linq;

namespace code.prep.movies
{
  public class MovieLibrary
  {
    readonly IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies;
    }

    public void add(Movie movie)
    {
      movies.Add(movie);
    }

      private IEnumerable<Movie> FilterOnCriteria(Func<Movie, bool> filterFunc)
      {
            var resultSet = new List<Movie>();

            foreach (var movie in all_movies())
            {
                if (filterFunc(movie))
                {
                    resultSet.Add(movie);
                }
            }

            return resultSet;
        }

      private IEnumerable<Movie> SortBy(Func<Movie, Movie, bool> sortFunc)
      {
          return MergeSort(all_movies(), sortFunc);
      }

      private IEnumerable<Movie> MergeSort(IEnumerable<Movie> movies, Func<Movie, Movie, bool> sortFunc)
      {
            var numberOfMovies = movies.Count();

            if (numberOfMovies == 1)
            {
                return movies;
            }

            var midIndex = numberOfMovies / 2;
            var leftPortion = GetElementsFrom(movies, 0, midIndex);
            var rightPortion = GetElementsFrom(movies, midIndex + 1, numberOfMovies - 1);

          var leftMerged = MergeSort(leftPortion, sortFunc);
          var rightMerged = MergeSort(rightPortion, sortFunc);

          return MergeTogether(leftMerged, rightMerged, sortFunc);
      }

      private IEnumerable<Movie> MergeTogether(IEnumerable<Movie> firstList, IEnumerable<Movie> secondList, Func<Movie, Movie, bool> sortFunc)
      {
          return new List<Movie>();
      }

      private IEnumerable<Movie> GetElementsFrom(IEnumerable<Movie> movies, int lo, int hi)
      {
          var resultSet = new List<Movie>();

          for (var i = lo; i <= hi; i++)
          {
                resultSet.Add(movies.ElementAt(i));
            }

          return resultSet;
      }

      public IEnumerable<Movie> all_movies_published_by_pixar()
      {
          return FilterOnCriteria(movie => movie.production_studio == ProductionStudio.Pixar);
      }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return FilterOnCriteria(movie => movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return FilterOnCriteria(movie => movie.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
            return FilterOnCriteria(movie => movie.date_published.Year > year);
        }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
            return FilterOnCriteria(movie => movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear);
        }

    public IEnumerable<Movie> all_kid_movies()
    {
            return FilterOnCriteria(movie => movie.genre == Genre.kids);
        }

    public IEnumerable<Movie> all_action_movies()
    {
            return FilterOnCriteria(movie => movie.genre == Genre.action);
        }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}
