﻿namespace SignalRWebUI.DtoViewModels.BookingDto
{
    public class ResultBookingDto
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime BookingTime { get; set; } 
    }
}
