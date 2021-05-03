using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Oscar.Domain.Models
{
    public class JsonMovies
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public DateTime Release_Date { get; set; }

    }
}
