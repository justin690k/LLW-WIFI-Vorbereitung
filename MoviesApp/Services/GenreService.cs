using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain;
using MoviesApp.Domain.Models;
using MoviesApp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services;

public interface IGenreService
{
    Task<IEnumerable<GenreDTO>> GetGenresAsync();
}

public class GenreService : IGenreService
{
    public async Task<IEnumerable<GenreDTO>> GetGenresAsync()
    {
        var result = await AppDbContext.Get.Genre          
           .Select(x => new GenreDTO
           {
               Id = x.Id,
               Genre = x.GenreValue,
           })
           .ToListAsync();
        return result;
    }
}
