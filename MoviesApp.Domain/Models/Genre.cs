using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Domain.Models;

public record Genre
{
    [Column("genre_id")]
    [Key]
    public int Id { get; set; }

    [Column("genre")]
    public required string GenreValue { get; set; }
}
