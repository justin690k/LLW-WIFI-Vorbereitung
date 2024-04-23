using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsApp.Domain.Models;

public class Employee
{
    [Column("employee_id")]
    public int Id { get; set; }
    public required string Firstname { get; set; }

    public required string Lastname { get; set; }
    public virtual Department? Department { get; set; }

    public List<Project>? Projects { get; set;}
}