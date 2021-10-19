using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaWeb.Shared.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int? SeatnoId { get; set; }
        public string User_Name { get; set; }
        public int ScreeningId { get; set; }
        public virtual Screening Screening { get; set; }
        [ForeignKey("SeatnoId")]
        public virtual Seatno Seatno { get; set; }
    }
    public class BookingWeb
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public string User_Name { get; set; }
        public string Movie { get; set; }
        public string Hall_Name { get; set; }
        public DateTime Screening_start { get; set; }

    }
}
