using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class AdultsMovieStoreStrategy : MovieAvailabilityStrategy
    {
        public bool IsAlreadyInTheMarket(Movie movie) //is available on the market on the release day
        {
            if (DateTime.Today.Year < movie.ReleaseDate.Year)
            {
                return false;
            }
            else if (DateTime.Today.Month < movie.ReleaseDate.Month)
            {
                return false;
            }
            else if ((DateTime.Today.Month == movie.ReleaseDate.Month && DateTime.Today.Day < movie.ReleaseDate.Day))
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
            int clientAge = client.CalculateAge();
            return clientAge >= 18;
        }

        public bool IsLegal(Movie movie)
        {
            return true;
        }
    }
}
