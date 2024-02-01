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
                        total += toAdd;
                        count += 1;
                    }
                }
                if (count >= 6)
                {
                    total = total * 0.9;
                }
                total = total + SecondFree(half);
            }


            return total;
        }

        public double SecondFree(List<MovieTicket> list)
        {
            double total = 0;
            double toAdd = 0;
            bool second = false;
            foreach (var MovieTicket in list)
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
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Friday;
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

                            sw.WriteLine("OrderNr: " + this.orderNr);
                            sw.WriteLine("IsStudentOrder: " + this.isStudentOrder);
                            foreach (var item in movieTickets)
                            {
                                sw.WriteLine(item.ToString());
                            }
                            sw.WriteLine("TotalCost: " + calculatePrice());
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