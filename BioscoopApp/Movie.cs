using static BioscoopApp.MovieScreening;
using System;
using System.Collections.Generic;

namespace BioscoopApp
{

class Movie
{
        // Properties
    public string Title { get; private set; }
    public List<MovieScreening> MovieScreenings { get; private set; } = new List<MovieScreening>();

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
            return $"Movie Details:\n" +
                   $"Title: {this.Title}\n";
    }
}
}