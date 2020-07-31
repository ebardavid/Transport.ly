using System.Collections.Generic;

namespace Trasnport.ly
{
    public interface IScheduleRepo
    {
        IEnumerable<Schedule> GetSchedules(int days);
    }
}