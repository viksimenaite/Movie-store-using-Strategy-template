using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class LimitedEditionMovieRentalStrategy : MovieRentalPeriodStrategy
    {
        public DateTime DetermineBaseRentalPeriod(Movie movie)
        {
            return DateTime.Today.AddDays(3);
        }

        public int DetermineBonusOfRentalPeriod(Client client, Movie movie)
        {
            int bonusDays = 0;
            if (client.TotalNoOfOrders > 30) //loyal client
            {
                bonusDays = 2;
            }
            return bonusDays;
        }

        public int DetermineReductionOfRentalPeriod(Movie movie)
        {
            int reducedDays = 0;
            if ((DateTime.Today.Year - movie.ReleaseDate.Year) == 1) {
                reducedDays = 2;
            }
            return reducedDays;
        }
    }
}
