using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class MovieStore
    {
        private MoviePriceStrategy moviePriceStrategy;
        private MovieAvailabilityStrategy movieAvailabilityStrategy;
        internal MoviePriceStrategy MoviePriceStrategy { get => moviePriceStrategy; set => moviePriceStrategy = value; }
        internal MovieAvailabilityStrategy MovieAvailabilityStrategy { get => movieAvailabilityStrategy; set => movieAvailabilityStrategy = value; }

        public MovieStore(MoviePriceStrategy moviePriceStrategy, MovieAvailabilityStrategy movieAvailabilityStrategy)
        {
            this.moviePriceStrategy = moviePriceStrategy;
            this.movieAvailabilityStrategy = movieAvailabilityStrategy;
        }

        public double Estimate(Client client, Movie movie)
        {
            if (movieAvailabilityStrategy.IsAppropriateAge(client, movie) && movieAvailabilityStrategy.IsLegal(movie) && movieAvailabilityStrategy.IsAlreadyInTheMarket(movie))
            {
                client.TotalNoOfOrders++;
                movie.TotalNoOfPurchases++;
                return (moviePriceStrategy.DeterminePrice(movie) + moviePriceStrategy.CountFees(movie)) * (1 - moviePriceStrategy.GetDiscount(client, movie));
            }
            else
            {
                return -1;
            }

        }
    }
}
