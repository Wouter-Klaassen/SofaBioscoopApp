using static BioscoopApp.MovieScreening;
using System;
namespace BioscoopApp
{

    public class MovieTicket
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

        public decimal GetPrice()
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
            String premiumExtraCharge = "";
            if (this.isPremium)
            {
                premiumExtraCharge = " (additional premium charges will be added)";
            }
            return $"\nMovie Ticket Details:\n" +
                    $"rowNr: {this.rowNr}\n" +
                    $"seatNr: {this.seatNr}\n" +
                    $"isPremium: {this.isPremium}\n" +
                    $"Movie Screening:\n {this.movieScreening}\n" +
                    $"price: {this.GetPrice():C}" +
                    $"{premiumExtraCharge}\n";
        }
    }
}