using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.DTOs;

public class GenreDTO
{
    public int Id { get; set; }
    public required string Genre { get; set; }
}
