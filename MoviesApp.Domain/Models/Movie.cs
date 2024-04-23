using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Domain.Models;

public record Movie
{
    [Column("movie_id")]
    [Key]
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Released { get; set; }
    public float Ranking { get; set; }
    [Column("first_year_revenue")]
    public int FirstYearRevenue { get; set; }
    public int Budget { get; set; }
    [Column("genre_id")]
    [ForeignKey(nameof(GenreId))]
    public int GenreId { get; set; }
    public virtual Genre? Genre { get; set; }

    [Column("director_id")]
    [ForeignKey(nameof(DirectorId))]
    public int DirectorId { get; set; }
    public virtual Director? Director { get; set; }
}
