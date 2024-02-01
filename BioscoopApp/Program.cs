using BioscoopApp;
using System;
class Program
{
    static void Main(string[] args)
    {
        Order firstOrder = new Order(1, false);
        Movie AngryBirdsMovie = new Movie("Angry Birds Movie");
        MovieScreening movieScreeningOne = new MovieScreening(new DateTime(2020, 12, 25), 4.5, AngryBirdsMovie);
        MovieTicket ticket = new MovieTicket(movieScreeningOne, false, 1, 1);
        firstOrder.addSeatReservation(ticket);
        firstOrder.export(TicketExportFormat.PLAINTEXT);
    }
}