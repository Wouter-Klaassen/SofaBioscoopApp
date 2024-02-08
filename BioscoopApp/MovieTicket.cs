using static BioscoopApp.MovieScreening;
using System;
namespace BioscoopApp
{

    public class MovieTicket
    {

        public int RowNr { get; private set; }
        public int SeatNr { get; private set; }
        public bool IsPremium { get; private set; }

        public MovieScreening MovieScreening { get; private set; }

        public MovieTicket(MovieScreening movieScreening , bool isPremiumReservation , int seatRow, int seatNr   )
        {
            this.RowNr = seatRow;
            this.SeatNr = seatNr;
            this.IsPremium = isPremiumReservation;
            this.MovieScreening = movieScreening;
        }

        public bool IsPremiumTicket()
        {
            return this.IsPremium;
        }

        public decimal GetPrice()
        {
            // kijken hoe we kunnen zorgen dat de premium hier toegevoegd wordt
            return this.MovieScreening.GetPricePerSeat();
        }

        public MovieScreening GetMovieScreening()
        {
            return this.MovieScreening;
        }

        public override string ToString()
        {
            String premiumExtraCharge = "";
            if (this.IsPremium)
            {
                premiumExtraCharge = " (additional premium charges will be added)";
            }
            return $"\nMovie Ticket Details:\n" +
                    $"rowNr: {this.RowNr}\n" +
                    $"seatNr: {this.SeatNr}\n" +
                    $"isPremium: {this.IsPremium}\n" +
                    $"Movie Screening:\n {this.MovieScreening}\n" +
                    $"price: {this.GetPrice():C}" +
                    $"{premiumExtraCharge}\n";
        }
    }
}