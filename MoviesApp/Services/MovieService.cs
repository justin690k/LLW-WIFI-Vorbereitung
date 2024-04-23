using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Domain;
using MoviesApp.Domain.Models;
using MoviesApp.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieDTO>> GetMovies();

    Task AddMovie(MovieDTO movieDTO);

    Task<bool> RemoveMovie(int  id);
}

public class MovieService : IMovieService
{
    public async Task AddMovie(MovieDTO movieDTO)
    {
        var movie = new Movie
        {
            Id = movieDTO.Id,
            Title = movieDTO.Title ?? "NOT FOUND",
            Budget = movieDTO.Budget,
            Director = new Director
            {
                Id = movieDTO.Director.Id,
                Firstname = movieDTO.Director.Firstname,
                Lastname = movieDTO.Director.Lastname,
            },
            FirstYearRevenue = movieDTO.FirstYearRevenue,
            Genre = new Genre
            {
                Id = movieDTO.Genre.Id,
                GenreValue = movieDTO.Genre.Genre,
            },
            Ranking = movieDTO.Ranking,
            Released = movieDTO.Released,
        };

        await AppDbContext.Get.Movies.AddAsync(movie);
        await AppDbContext.Get.SaveChangesAsync();

    }

    public async Task<IEnumerable<MovieDTO>> GetMovies()
    {
        var result = await AppDbContext.Get.Movies
            .Include(nameof(Director))
            .Include(nameof(Genre))
            .Select(x => new MovieDTO
            {
                Id = x.Id,
                Title = x.Title,
                Budget = x.Budget,
                Director = new DirectorDTO 
                {
                    Id=x.DirectorId,
                    Firstname = x.Director.Firstname ?? "Not Found",
                    Lastname = x.Director.Lastname ?? "Not Found",
                },
                FirstYearRevenue = x.FirstYearRevenue,
                Genre = new GenreDTO
                {
                    Id = x.GenreId,
                    Genre = x.Genre.GenreValue ?? "Not Found",
                },
                Ranking = x.Ranking,
                Released = x.Released,
            })
            .ToListAsync();
        return result;
    }

    public async Task<bool> RemoveMovie(int id)
    {
        var item = await AppDbContext.Get.Movies.FindAsync(id);
        if (item is null)
            return false;

        AppDbContext.Get.Movies.Remove(item);
        AppDbContext.Get.SaveChanges();
        return true;
    }
}
