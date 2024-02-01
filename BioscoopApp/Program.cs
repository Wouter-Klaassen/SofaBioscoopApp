using BioscoopApp;
using System;
class Program
{
    static void Main(string[] args)
    {
        Order firstOrder = new Order(1, false);
        Movie AngryBirdsMovie = new Movie("Angry Birds Movie");
        MovieScreening movieScreeningOne = new MovieScreening(new DateTime(2024, 02, 03), 4.5, AngryBirdsMovie);
        MovieScreening movieScreeningTwo = new MovieScreening(new DateTime(2024, 02, 01), 4.5, AngryBirdsMovie);
        MovieTicket ticket = new MovieTicket(movieScreeningOne, false, 1, 1);
        MovieTicket ticket2 = new MovieTicket(movieScreeningOne, true, 1, 2);
        MovieTicket ticket3 = new MovieTicket(movieScreeningOne, false, 1, 4);
        MovieTicket ticket4 = new MovieTicket(movieScreeningOne, false, 1, 5);
        MovieTicket ticket5 = new MovieTicket(movieScreeningOne, false, 1, 6);
        MovieTicket ticket6 = new MovieTicket(movieScreeningOne, false, 1, 7);
        MovieTicket ticket7 = new MovieTicket(movieScreeningTwo, false, 1, 6);
        MovieTicket ticket8 = new MovieTicket(movieScreeningTwo, false, 1, 7);
        firstOrder.addSeatReservation(ticket);
        firstOrder.addSeatReservation(ticket2);
        firstOrder.addSeatReservation(ticket3);
        firstOrder.addSeatReservation(ticket4);
        firstOrder.addSeatReservation(ticket5);
        firstOrder.addSeatReservation(ticket6);
        firstOrder.addSeatReservation(ticket7);
        firstOrder.addSeatReservation(ticket8);
        firstOrder.export(TicketExportFormat.PLAINTEXT);
    }
}