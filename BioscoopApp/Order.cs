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
            double toAdd = 0;
            int count = 0;
            List<MovieTicket> half = new List<MovieTicket>();
            if (isStudentOrder)
            {
                total = SecondFree(this.movieTickets);
            }
            else
            {
                foreach (var MovieTicket in movieTickets)
                {
                    if (!IsWeekend(MovieTicket.movieScreening.DateAndTime))
                    {
                        half.Add(MovieTicket);
                    }
                    else
                    {
                        toAdd = MovieTicket.GetPrice();
                        if (MovieTicket.isPremiumTicket())
                        {
                            toAdd += 3;
                        }
                        count += 1;
                    }
                }
                if (count >= 6)
                {
                    toAdd = toAdd * 0.9;
                }
                total = toAdd + SecondFree(half);
            }


            return total;
        }

        public double SecondFree(List<MovieTicket> list)
        {
            double total = 0;
            double toAdd = 0;
            bool second = false;
            foreach (var MovieTicket in movieTickets)
            {
                toAdd = MovieTicket.GetPrice();
                if (MovieTicket.isPremiumTicket())
                {
                    if (isStudentOrder)
                    {
                        toAdd += 2;
                    }
                    else
                    {
                        toAdd += 3;
                    }
                }
                if (second)
                {
                    toAdd = 0;
                    second = false;
                }
                else
                {
                    second = true;
                }
                total += toAdd;
            }
            return total;
        }
        public bool IsWeekend(DateTime dateTime)
        {
            DayOfWeek dayOfWeek = dateTime.DayOfWeek;
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }

        public void export(TicketExportFormat exportFormat )
        {

            string path = @"C:\Users\thoma\OneDrive\Documenten\github\SofaBioscoopApp\BioscoopApp\Output\MyTest.txt";
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
                                sw.WriteLine("\nMovie Tickets:\n" + MovieTicket.ToString());
                                sw.WriteLine("\nTotal price of order: " + calculatePrice());
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