using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class MovieRental
    {
        private MoviePriceStrategy moviePriceStrategy;
        private MovieRentalPeriodStrategy movieRentalPeriodStrategy;
        private MovieAvailabilityStrategy movieAvailabilityStrategy;

        internal MoviePriceStrategy MoviePriceStrategy { get => moviePriceStrategy; set => moviePriceStrategy = value; }
        internal MovieRentalPeriodStrategy MovieRentalPeriodStrategy { get => movieRentalPeriodStrategy; set => movieRentalPeriodStrategy = value; }
        internal MovieAvailabilityStrategy MovieAvailabilityStrategy { get => movieAvailabilityStrategy; set => movieAvailabilityStrategy = value; }

        public MovieRental(MoviePriceStrategy moviePriceStrategy, MovieRentalPeriodStrategy movieRentalPeriodStrategy, MovieAvailabilityStrategy movieAvailabilityStrategy)
        {
            this.moviePriceStrategy = moviePriceStrategy;
            this.movieRentalPeriodStrategy = movieRentalPeriodStrategy;
            this.movieAvailabilityStrategy = movieAvailabilityStrategy;
        }

        public double EstimatePrice(Client client, Movie movie)
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

        public DateTime EstimateRentalPeriod(Client client, Movie movie)
        {
            DateTime rentalPeriod = movieRentalPeriodStrategy.DetermineBaseRentalPeriod(movie).AddDays(movieRentalPeriodStrategy.DetermineBonusOfRentalPeriod(client, movie)).AddDays((-1) * movieRentalPeriodStrategy.DetermineReductionOfRentalPeriod(movie));
            if(rentalPeriod > DateTime.Today)
            {
                return rentalPeriod;
            }
            else
            {
                return DateTime.MinValue;
            }

        }
    }
}
