using System;
using System.ComponentModel.DataAnnotations;

namespace Oscar.Domain.Models
{
    public class Studio
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

    }
}
