using MediatR;
using Oscar.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Oscar.Mediator.ClientCommands
{
    public class InsertMovieCommand : IRequest
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public DateTime Release_Date { get; set; }
    }
}
