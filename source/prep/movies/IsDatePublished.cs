using System;
using code.utility.matching;

namespace code.prep.movies
{
    public class IsDatePublished : IMatchA<Movie>
    {
        private readonly int year;
        private readonly DateComparer dateComparer;

        public IsDatePublished(int year, DateComparer comparer)
        {
            this.year = year;
            this.dateComparer = comparer;
        }

        public bool matches(Movie item)
        {
            var movieYear = item.date_published.Year;

            switch (dateComparer)
            {
                case DateComparer.After:
                    return movieYear > year;
                case DateComparer.Before:
                    return movieYear < year;
                case DateComparer.OnOrAfter:
                    return movieYear >= year;
                case DateComparer.OnOrBefore:
                    return movieYear <= year;
            }

            return item.date_published.Year < year;
        }
    }

    public enum DateComparer
    {
        After,
        Before,
        OnOrAfter,
        OnOrBefore
    }
}