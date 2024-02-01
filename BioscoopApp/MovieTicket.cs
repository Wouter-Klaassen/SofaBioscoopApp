using static BioscoopApp.MovieScreening;
using System;
namespace BioscoopApp
{

    class MovieTicket
    {

        private int rowNr { get; set; }
        private int seatNr { get; set; }
        private bool isPremium { get; set; }

        public MovieScreening movieScreening { get; set; }

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