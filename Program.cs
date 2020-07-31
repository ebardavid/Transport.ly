using System;

namespace Trasnport.ly
{
    partial class Program
    {

        const int MAX_BOXES = 20;
        static void Main(string[] args)
        {
            IOrderRepo orderRepo = new OrderRepo();
            IScheduleRepo scheduleRepo = new ScheduleRepo();
            var inventoryManager = new InventoryManager(orderRepo, scheduleRepo);

            //USER STORY 1
            inventoryManager.GenerateSchedulesByDays(2);

            inventoryManager.PrintFlightSchedules();

            //USER STORY 2
            //user entries for applying flight schedules
            inventoryManager.ApplyFlightSchedule(1, MAX_BOXES);
            inventoryManager.ApplyFlightSchedule(2, MAX_BOXES);
            inventoryManager.ApplyFlightSchedule(3, MAX_BOXES);
            inventoryManager.ApplyFlightSchedule(4, MAX_BOXES);
            inventoryManager.ApplyFlightSchedule(5, MAX_BOXES);
            inventoryManager.ApplyFlightSchedule(6, MAX_BOXES);

            inventoryManager.PrintFlightItineraries();
            Console.ReadLine();
        }
    }
}
