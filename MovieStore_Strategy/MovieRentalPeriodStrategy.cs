using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    interface MovieRentalPeriodStrategy
    {
        DateTime DetermineBaseRentalPeriod(Movie movie); 
        int DetermineReductionOfRentalPeriod(Movie movie);//by days
        int DetermineBonusOfRentalPeriod(Client client, Movie movie);//by days
    }
}
