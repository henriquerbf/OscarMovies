using System;
using System.ComponentModel.DataAnnotations;


namespace Oscar.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public int Id_Received { get; set; }

        [StringLength (50, MinimumLength=3)]
        public string Title { get; set; }

        public DateTime Release_Date { get; set; }

        public Studio Studio { get; set; }

    }
}
