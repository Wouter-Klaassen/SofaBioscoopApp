using static BioscoopApp.Movie;
using System;

namespace BioscoopApp
{
    public class MovieScreening
{
        // Properties
    public DateTime DateAndTime { get; private set; }
    public decimal PricePerSeat { get; private set; }
    public Movie Movie { get; private set; }

    // Constructor
    public MovieScreening(DateTime dateAndTime, decimal pricePerSeat, Movie movie)
    {
        DateAndTime = dateAndTime;
        PricePerSeat = pricePerSeat;
        Movie = movie;
    }

    // Method to get the price per seat
    public decimal GetPricePerSeat()
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

