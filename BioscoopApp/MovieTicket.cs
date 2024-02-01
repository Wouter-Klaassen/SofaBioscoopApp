using static BioscoopApp.MovieScreening;
using System;
namespace BioscoopApp
{

    class MovieTicket
    {

        public int rowNr { get; private set; }
        public int seatNr { get; private set; }
        public bool isPremium { get; private set; }

        public MovieScreening movieScreening { get; private set; }

        public MovieTicket(MovieScreening movieScreening , bool isPremiumReservation , int seatRow, int seatNr   )
        {
            this.rowNr = seatRow;
            this.seatNr = seatNr;
            this.isPremium = isPremiumReservation;
            this.movieScreening = movieScreening;
        }

        public bool isPremiumTicket()
        {
            return this.isPremium;
        }

        public double GetPrice()
        {
            // kijken hoe we kunnen zorgen dat de premium hier toegevoegd wordt
            return this.movieScreening.GetPricePerSeat();
        }

        public MovieScreening GetMovieScreening()
        {
            return this.movieScreening;
        }

        public override string ToString()
        {
            return $"\nMovie Ticket Details:\n" +
                    $"rowNr: {rowNr}\n" +
                    $"seatNr: {seatNr}\n" +
                    $"isPremium: {isPremium}\n" +
                    $"Movie Screening:\n {movieScreening}\n" +
                    $"priceTotal: {this.GetPrice():C}\n";
        }
    }
}