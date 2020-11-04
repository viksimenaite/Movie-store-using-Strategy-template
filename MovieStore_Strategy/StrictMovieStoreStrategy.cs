using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class StrictMovieStoreStrategy : MovieAvailabilityStrategy
    {
        public bool IsAlreadyInTheMarket(Movie movie)
        {
            DateTime availableDate = movie.ReleaseDate.AddMonths(8);
            if (DateTime.Today.Year < availableDate.Year)
            {
                return false;
            }
            else if (DateTime.Today.Month < availableDate.Month)
            {
                return false;
            }
            else if ((DateTime.Today.Month == availableDate.Month && DateTime.Today.Day < availableDate.Day))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsAppropriateAge(Client client, Movie movie)
        {
            return true;
        }

        public bool IsLegal(Movie movie)
        {
            return movie.AgeRating == MPAARating.G || movie.AgeRating == MPAARating.PG;
        }
    }
}
