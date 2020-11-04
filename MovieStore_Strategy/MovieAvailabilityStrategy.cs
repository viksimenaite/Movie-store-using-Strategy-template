using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    interface MovieAvailabilityStrategy
    {
        bool IsAppropriateAge(Client client, Movie movie);
        bool IsLegal(Movie movie);
        bool IsAlreadyInTheMarket(Movie movie);
    }
}
