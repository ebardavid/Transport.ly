using System.Collections.Generic;

namespace Trasnport.ly
{
    public class Flight {
        public Flight(int numOfBoxes, Schedule schedule) {
            NumOfBoxes = numOfBoxes;
            Schedule = schedule;
            Orders = new List<Order>();
            Schedule.IsApplied = true;
        }
        public IEnumerable<Order> Orders { get; set; }
        public Schedule Schedule { get; private set; }
        public int NumOfBoxes { get; private set; }

    }
}
