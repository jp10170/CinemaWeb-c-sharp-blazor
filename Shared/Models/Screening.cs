using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaWeb.Shared.Models
{
    public class Screening
    {
        public int Id { get; set; }
        public DateTime Screening_start { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("HallId")]
        public virtual Hall Hall { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
    }

    public class ScreeningWeb
    {
        public int Id { get; set; }
        public DateTime Screening_start { get; set; }
        public string Hall { get; set; }
        public string Movie { get; set; }
    }
}
