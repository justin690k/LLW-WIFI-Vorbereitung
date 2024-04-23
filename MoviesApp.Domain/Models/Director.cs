using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Domain.Models;

public record Director
{
    [Column("director_id")]
    [Key]
    public int Id { get; set; }

    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
}
