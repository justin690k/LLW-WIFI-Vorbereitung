using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Domain.Models;
using MoviesApp.Model.DTOs;
using MoviesApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<MovieDTO> _movies;
    [ObservableProperty]
    private IEnumerable<DirectorDTO> _directors;
    [ObservableProperty]
    private IEnumerable<GenreDTO> _genres;

    [ObservableProperty]
    private bool _showAddPopUp;

    [ObservableProperty]
    private MovieDTO _selectedItem;


    private readonly IMovieService _movieService;
    private readonly IDirectorService _directorService;
    private readonly IGenreService _genreService;
    public MainViewModel(IServiceProvider serviceProvider)
    {
        _movieService = serviceProvider.GetRequiredService<IMovieService>();
        _directorService = serviceProvider.GetRequiredService<IDirectorService>();
        _genreService = serviceProvider.GetRequiredService<IGenreService>();

        UpdateList();
    }

    private async void UpdateList()
    {
        Movies = new ObservableCollection<MovieDTO>(await _movieService.GetMovies());
        Genres = await _genreService.GetGenresAsync();
        Directors = await _directorService.GetDirectors();
    }

    [RelayCommand]
    private void ToggleAddPopUp()
    {
        ShowAddPopUp = !ShowAddPopUp;

        SelectedItem = new MovieDTO();
    }

    [RelayCommand]
    private void ToggleEditPopUp()
    {
        if (SelectedItem is null)
            return;

        ShowAddPopUp = !ShowAddPopUp;
    }

    private bool CanAddMovie() => true;

    [RelayCommand(CanExecute = nameof(CanAddMovie))]
    private async Task AddMovieAsync()
    {
        if (!CanAddMovie())
            return;

        await _movieService.AddMovie(SelectedItem);
    }

    private bool CanRemoveMovie() => true;

    [RelayCommand(CanExecute = nameof(CanRemoveMovie))]
    private async Task RemoveMovie(int  movieId)
    {
        if (movieId <= 0)
            return;

        await _movieService.RemoveMovie(movieId);
    }
}
