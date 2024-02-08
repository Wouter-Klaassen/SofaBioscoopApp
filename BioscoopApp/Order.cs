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

    public class Order
    {
        public int OrderNr { get; private set; }
        public bool IsStudentOrder { get; private set; }
        public List<MovieTicket> MovieTickets { get; set; } = new List<MovieTicket>();

        public Order( int orderNr , bool isStudentOrder  )
        {
            this.IsStudentOrder = isStudentOrder;
            this.OrderNr = orderNr;
        }

        public int GetOrder()
        {
            return this.OrderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            this.MovieTickets.Add(ticket);
        }

        public decimal CalculatePrice()
        {
            decimal total = 0;
            decimal toAdd = 0;
            int count = 0;
            List<MovieTicket> half = new List<MovieTicket>();
            foreach (var MovieTicket in MovieTickets)
            {
                DayOfWeek dayOfWeek = MovieTicket.MovieScreening.DateAndTime.DayOfWeek;
                bool isWeekend = dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Friday;
                // studenten hebben altijd de tweede ticket gratis
                // niet studenten hebben doordeweeks ook altijd de 2e gratis,
                // worden toegevoegd aan een list om naar de SecondFree methode te sturen
                if (!isWeekend || this.IsStudentOrder)
                {
                    half.Add(MovieTicket);
                }
                else
                {
                    // prijs van het ticket word opgehaald uit MovieTicket en daarna toegevoegd aan total
                    toAdd = MovieTicket.GetPrice();
                    // als het een premium ticket is, kost het 3 dollar extra (geen student)
                    if (MovieTicket.IsPremiumTicket())
                    {
                        toAdd += 3;
                    }
                    total += toAdd;
                    count += 1;
                }
            }
            // als er 6 of meer (niet 2e gratis) tickets besteld zijn krijg je hier 10% korting op
            if (count >= 6)
            {
                total = total * 0.9M;
            }
            total = total + SecondFree(half);
            return total;
        }

        public decimal SecondFree(List<MovieTicket> list)
        {
            decimal total = 0;
            decimal toAdd = 0;
            bool second = false;
            foreach (var MovieTicket in list)
            {
                toAdd = MovieTicket.GetPrice();
                // als het een premium ticket is, kost het 2 (student) of 3 (geen student) dollar extra 
                if (MovieTicket.IsPremiumTicket())
                {
                    if (IsStudentOrder)
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

        public void Export(TicketExportFormat exportFormat )
        {

            string path = @"C:\Output\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    switch (exportFormat)
                    {
                        case PLAINTEXT:

                            sw.WriteLine("OrderNr: " + this.OrderNr);
                            sw.WriteLine("IsStudentOrder: " + this.IsStudentOrder);
                            foreach (var item in MovieTickets)
                            {
                                sw.WriteLine(item.ToString());
                            }
                            sw.WriteLine("TotalCost: $" + CalculatePrice());
                            break;

                        case JSON:

                            var aList = this.MovieTickets.Select(item => new
                            {
                                rowNr = item.RowNr,
                                seatNr = item.SeatNr,
                                isPremium = item.IsPremium,
                                dateAndTime = item.MovieScreening.DateAndTime,
                                pricePerSeat = item.MovieScreening.GetPricePerSeat(),
                                movieTitle = item.MovieScreening.Movie.Title,
                            }).ToList();

                            var Result = new
                            {
                                orderNr = this.OrderNr,
                                isStudentOrder = this.IsStudentOrder,
                                tickets = new
                                {
                                    items = JsonSerializer.Serialize(aList),
                                },
                                totalPrice = CalculatePrice()

                            };
                            sw.WriteLine(Result);
                            break;

                    }
                }
            }
        }
    }
}