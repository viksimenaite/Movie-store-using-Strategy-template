using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class LongPeriodMovieRentalStrategy : MovieRentalPeriodStrategy
    {
        public DateTime DetermineBaseRentalPeriod(Movie movie)
        {
            return DateTime.Today.AddDays(30);
        }

        public int DetermineBonusOfRentalPeriod(Client client, Movie movie)
        {
            int bonusDays = 0;
            if (client.TotalNoOfOrders > 20) //loyal client
            {
                bonusDays = 7;
            }else if (client.CalculateAge() < 16)
            {
                bonusDays = 2;
            }
            return bonusDays;
        }

        public int DetermineReductionOfRentalPeriod(Movie movie)
        {
            return 0;
        }
    }
}
