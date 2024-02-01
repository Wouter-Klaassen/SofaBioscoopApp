using static BioscoopApp.MovieTicket;
using System.Collections.Generic;
using static BioscoopApp.TicketExportFormat;
using System;
using System.IO;
using System.Text.Json;

namespace BioscoopApp
{

    class Order
    {
        private int orderNr { get; set; }
        private bool isStudentOrder { get; set; }
        private List<MovieTicket> movieTickets { get; set; } = new List<MovieTicket>();

        public Order( int orderNr , bool isStudentOrder  )
        {
            this.isStudentOrder = isStudentOrder;
            this.orderNr = orderNr;
        }

        public int getOrder()
        {
            return this.orderNr;
        }

        public void addSeatReservation(MovieTicket ticket  )
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
                            foreach (var MovieTicket in movieTickets)
                            {
                                sw.WriteLine("OrderNr: " + this.orderNr);
                                sw.WriteLine("\nIsStudentOrder: " + this.isStudentOrder);
                                sw.WriteLine("\nMovie Tickets: " + MovieTicket.ToString());
                            }
                            break;
                        case JSON:
                            foreach (var MovieTicket in movieTickets)
                            {
                                sw.WriteLine(JsonSerializer.Serialize(this));
                                sw.WriteLine(JsonSerializer.Serialize(MovieTicket)); 
                        }
                            break;

                    }
                }
            }
        }
    }
}