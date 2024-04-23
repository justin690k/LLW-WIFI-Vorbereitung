using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.DTOs;

public class MovieDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int Released { get; set; }
    public float Ranking { get; set; }
    public int FirstYearRevenue { get; set; }
    public int Budget { get; set; }
    public GenreDTO? Genre { get; set; }
    public DirectorDTO? Director { get; set; }
}
