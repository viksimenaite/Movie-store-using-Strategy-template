using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    interface MovieAvailabilityStrategy
    {
        Boolean IsAppropriateAge(Client client, Movie movie);
        Boolean IsLegal(Movie movie);
        Boolean IsAlreadyInTheMarket(Movie movie);
    }
}
