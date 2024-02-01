using static BioscoopApp.Movie;
using System;

namespace BioscoopApp
{
class MovieScreening
{
    // Properties
    public DateTime DateAndTime { get; set; }
    private double PricePerSeat { get; set; }
    private Movie Movie { get; set; }

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

    public DateTime GetDateAndTime()
        {
            return DateAndTime;
        }

    // ToString method override
    public override string ToString()
    {
        return $"Movie Screening Details:\n" +
               $"Date and Time: {DateAndTime}\n" +
               $"Price per Seat: {PricePerSeat:C}\n" +
               $"Movie: {Movie}";
    }
}    
}

