using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaWeb.Shared.Models
{
    public class Seatno
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int HallId { get; set; }
        [ForeignKey("HallId")]
        public virtual Hall Hall { get; set; }
    }

    public class SeatWeb
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int HallId { get; set; }
    }
}
