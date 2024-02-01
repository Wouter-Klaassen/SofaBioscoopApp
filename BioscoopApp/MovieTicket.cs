using static BioscoopApp.MovieScreening;
using System;
namespace BioscoopApp
{

    class MovieTicket
    {

        private int rowNr { get; set; }
        private int seatNr { get; set; }
        private bool isPremium { get; set; }

        private MovieScreening movieScreening { get; set; }

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

        public string toString()
        {
            return $"Movie Ticket Details:\n" +
                    $"rowNr: {rowNr}\n" +
                    $"seatNr: {seatNr:C}\n" +
                    $"isPremium: {isPremium}\n" +
                    $"priceTotal: {this.GetPrice()}\n" +
                    $"Movie Screening: {movieScreening}";
        }
    }
}