using MoviesApp.Domain.Models;
using MoviesApp.Domain;
using MoviesApp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MoviesApp.Services;

public interface IDirectorService
{
    Task<IEnumerable<DirectorDTO>> GetDirectors();
}

public class DirectorService : IDirectorService
{
    public async Task<IEnumerable<DirectorDTO>> GetDirectors()
    {
        var result = await AppDbContext.Get.Directors           
           .Select(x => new DirectorDTO
           {
               Id = x.Id,
               Firstname = x.Firstname,
               Lastname = x.Lastname
           })
           .ToListAsync();
        return result;
    }
}
