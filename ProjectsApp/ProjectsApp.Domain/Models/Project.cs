using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsApp.Domain.Models;

public class Project
{
    [Column("project_id")]
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public virtual Employee? Leader { get; set; } 

    public int Budget { get; set; }
}
