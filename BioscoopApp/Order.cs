using static BioscoopApp.MovieTicket;
using System.Collections.Generic;
using static BioscoopApp.TicketExportFormat;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace BioscoopApp
{

    class Order
    {
        public int orderNr { get; private set; }
        public bool isStudentOrder { get; private set; }
        public List<MovieTicket> movieTickets { get; set; } = new List<MovieTicket>();

        public Order( int orderNr , bool isStudentOrder  )
        {
            this.isStudentOrder = isStudentOrder;
            this.orderNr = orderNr;
        }

        public int getOrder()
        {
            return this.orderNr;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            this.movieTickets.Add(ticket);
        }

        public double calculatePrice()
        {
            double total = 0;
    
        foreach (var MovieTicket in movieTickets)
            {
                total += MovieTicket.GetPrice();
        }

            return total;
        }

        public void export(TicketExportFormat exportFormat )
        {

            string path = @"C:\School\Jaar-3\Sofa\BioscoopApp\BioscoopApp\BioscoopApp\Output\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    switch (exportFormat)
                    {
                        case PLAINTEXT:

                            sw.WriteLine("OrderNr: " + this.orderNr);
                            sw.WriteLine("IsStudentOrder: " + this.isStudentOrder);
                            foreach (var item in movieTickets)
                            {
                                sw.WriteLine(item.ToString());
                            }
                            break;

                        case JSON:

                            var aList = this.movieTickets.Select(item => new
                            {
                                rowNr = item.rowNr,
                                seatNr = item.seatNr,
                                isPremium = item.isPremium,
                                dateAndTime = item.movieScreening.DateAndTime,
                                pricePerSeat = item.movieScreening.GetPricePerSeat(),
                                movieTitle = item.movieScreening.Movie.Title,
                            }).ToList();

                            var Result = new
                            {
                                orderNr = this.orderNr,
                                isStudentOrder = this.isStudentOrder,
                                tickets = new
                                {
                                    items = JsonSerializer.Serialize(aList),
                                }

                            };
                            sw.WriteLine(Result);
                            break;

                    }
                }
            }
        }
    }
}