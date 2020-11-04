using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class FamilyFriendlyMovieStoreStrategy : MovieAvailabilityStrategy
    {
        public bool IsAlreadyInTheMarket(Movie movie)
        {
            DateTime availableDate = movie.ReleaseDate.AddMonths(2); //is available on the market after 2 months after release day
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
            bool isAppropriate = false;
            int clientAge = client.CalculateAge();

            switch (movie.AgeRating)
            {
                case MPAARating.G:
                    isAppropriate = true;
                    break;
                case MPAARating.PG:
                    isAppropriate = true;
                    break;
                case MPAARating.PG_13:
                    if (clientAge >= 13)
                    {
                        isAppropriate = true;
                    }
                    break;
                case MPAARating.R:
                    if (clientAge >= 17)
                    {
                        isAppropriate = true;
                    }
                    break;
                case MPAARating.NC_17:
                    if (clientAge >= 18)
                    {
                        isAppropriate = true;
                    }
                    break;
                default:
                    throw new ArgumentException("Unknown age rating.");
            }
            return isAppropriate;
        }

        public bool IsLegal(Movie movie)
        {
            return true;
        }
    }
}
