using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.DTOs;

public class DirectorDTO
{
    public int Id { get; set; }

    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
}
