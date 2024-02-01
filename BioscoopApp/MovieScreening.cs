using static BioscoopApp.Movie;
using System;

namespace BioscoopApp
{
class MovieScreening
{
        // Properties
    public DateTime DateAndTime { get; private set; }
    public double PricePerSeat { get; private set; }
    public Movie Movie { get; private set; }

    // Constructor
    public MovieScreening(DateTime dateAndTime, double pricePerSeat, Movie movie)
    {
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
        Movie = movie;
    }

    // Method to get the price per seat
    public double GetPricePerSeat()
    {
        return PricePerSeat;
    }

    // ToString method override
    public override string ToString()
    {
        return $"Movie Screening Details:\n" +
               $"Date and Time: {this.DateAndTime}\n" +
               $"Price per Seat: {this.PricePerSeat:C}\n" +
               $"{this.Movie}";
    }
}    
}

