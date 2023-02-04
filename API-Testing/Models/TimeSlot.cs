using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Testing.Models
{
    public class TimeSlot
    {
        public int TSId { get; set; }
        public string TSCode { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int RoomId { get; set; }
        public string Status { get; set; }
    }
}
