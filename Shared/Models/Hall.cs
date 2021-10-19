using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CinemaWeb.Shared.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Seats_Number { get; set; }
    }
}
