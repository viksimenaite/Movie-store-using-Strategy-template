using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore_Strategy
{
    class LuxuryMovieStoreStrategy : MoviePriceStrategy
    {
        private readonly double loyalDiscount = 0.15;

        public double CountFees(Movie movie)
        {
            return 0.0; //shady store
        }

        public double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice;
            if (movie.TotalNoOfPurchases > 1500) //if movie is popular
            {
                price += 5.5;
            }

            if ((DateTime.Today.Year - movie.ReleaseDate.Year) > 60) //if a movie is vintage
            {
                price += 4.3;
            }
            return price + 10.2;
        }

        public double GetDiscount(Client client, Movie movie)
        {
            double discount = 0;
            if (client.TotalNoOfOrders > 30) //loyal client
            {
                discount = loyalDiscount;
            }
            return discount;
        }
    }
}
