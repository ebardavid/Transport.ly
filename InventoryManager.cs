using System;
using System.Collections.Generic;
using System.Linq;

namespace Trasnport.ly
{
    public class InventoryManager
    {
        private readonly IOrderRepo orderRepo;
        private readonly IScheduleRepo scheduleRepo;
        public IEnumerable<Schedule> Schedules { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }
        public List<Flight> Flights { get; private set; }

        public InventoryManager(IOrderRepo orderRepo, IScheduleRepo scheduleRepo)
        {
            this.orderRepo = orderRepo;
            this.scheduleRepo = scheduleRepo;
        }

        public void GenerateSchedulesByDays(int days)
        {
            this.Schedules = this.scheduleRepo.GetSchedules(days);
        }

        public void ApplyFlightSchedule(int flightNum, int numOfBoxes)
        {
            if (flightNum < 1 || numOfBoxes < 1) return;
            if (this.Flights == null)   {
                this.Flights = new List<Flight>();
            }
            var schedule = this.Schedules.FirstOrDefault(s => s.FlightNum == flightNum);
            if (schedule != null)
            {
                this.Flights.Add(new Flight(numOfBoxes, schedule));
            }
        }

        public void PrintFlightSchedules()
        {
            Console.WriteLine($"********************** FLIGHT SCHEDULES **********************");
            if (this.Schedules == null)
            {
                Console.WriteLine($"There are currently no scheduled flights");
            }
            else
            {
                foreach (var s in this.Schedules)
                {
                    Console.WriteLine($"Flight: {s.FlightNum}, departure: {s.Departure}, arrival: {s.Arrival}, day: {s.Day}");
                }
            }
        }
        public void PrintFlightItineraries() {
            Console.WriteLine($"********************** FLIGHT ITINERARIES **********************");
            applyScheduledFlightOrders();
            if (this.Orders == null)
            {
                Console.WriteLine($"There are no flight orders found");
            }
            else
            {
                foreach (var appliedOrder in this.Orders.Where(o => o.IsApplied()))
                {
                    Console.WriteLine($"order: {appliedOrder.Id}, flightNumber: {appliedOrder.Schedule.FlightNum}, departure: {appliedOrder.Schedule.Departure}, arrival: {appliedOrder.Schedule.Arrival}, day: {appliedOrder.Schedule.Day}");
                }
                foreach (var pendingOrder in this.Orders.Where(o => !o.IsApplied()))
                {
                    Console.WriteLine($"order: {pendingOrder.Id}, flightNumber: not scheduled");
                }
            }
        }

        private void applyScheduledFlightOrders()
        {
            if (this.Schedules == null && this.Flights == null) return;
            this.Orders = orderRepo.GetOrders();
            foreach (var s in this.Schedules)
            {
                var appliedScheduledFlights = this.Flights.Where(f => f.Schedule == s);
                foreach (var f in appliedScheduledFlights)
                {
                    var pendingOrders = this.Orders.Where(o => o.Destination == f.Schedule.Arrival && !o.IsApplied()).Take(f.NumOfBoxes).ToList();
                    //update pending orders as applied orders
                    foreach (var o in pendingOrders) {
                        o.Schedule = s;
                    };
                    f.Orders = pendingOrders;
                }

            }
        }
    }
}
