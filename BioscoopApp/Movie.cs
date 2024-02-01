using static BioscoopApp.MovieScreening;
using System;
using System.Collections.Generic;

namespace BioscoopApp
{

class Movie
{
    // Properties
    private string Title { get; set; }
    private List<MovieScreening> MovieScreenings { get; set; } = new List<MovieScreening>();

    // Constructor
    public Movie(string title)
    {
        Title = title;
    }

    // Method to add a screening to the list
    public void AddScreening(MovieScreening screening)
    {
        MovieScreenings.Add(screening);
    }

    // ToString method override
    public override string ToString()
    {
        string screeningsInfo = "No screenings available";

        if (MovieScreenings.Count > 0)
        {
            screeningsInfo = "Screenings:\n";
            foreach (var screening in MovieScreenings)
            {
                screeningsInfo += $"{screening}\n";
            }
        }

        return $"Movie Details:\n" +
               $"Title: {Title}\n" +
               $"{screeningsInfo}";
    }
}
}