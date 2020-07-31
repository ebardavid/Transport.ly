using System.Collections.Generic;

namespace Trasnport.ly
{
    public class ScheduleRepo: IScheduleRepo
    {
        public IEnumerable<Schedule> GetSchedules(int days)
        {
            if (days < 1) return null;
            var schedules = new List<Schedule>();
            var flightNum = 0;
            for (var i = 0; i < days; i++) {
                var currDay = i + 1;            
                schedules.Add(new Schedule { FlightNum = ++flightNum, Day = currDay, Departure = "YUL", Arrival = "YYZ" });
                schedules.Add(new Schedule { FlightNum = ++flightNum, Day = currDay, Departure = "YUL", Arrival = "YYC" });
                schedules.Add(new Schedule { FlightNum = ++flightNum, Day = currDay, Departure = "YUL", Arrival = "YVR" });
            }
            return schedules;
        }
    }
}
