using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    interface MoviePriceStrategy
    {
        double DeterminePrice(Movie movie);
        double GetDiscount(Client client, Movie movie);
        double CountFees(Movie movie);
    }
}
