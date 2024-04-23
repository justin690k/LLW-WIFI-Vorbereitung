using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using ProjectsApp.Domain.Models;
using ProjectsApp.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsApp.WPF.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Project> _projects;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(RemoveCommand), nameof(AddCommand), nameof(ToggleEditPopUpCommand))]
    private Project _selectedItem;

    [ObservableProperty]
    private bool _showPopUp;

    [ObservableProperty]
    private IEnumerable<Employee> _employees;

    private readonly IProjectService _projectService;
    public MainViewModel(IServiceProvider serviceProvider)
    {
        _projectService = serviceProvider.GetRequiredService<IProjectService>();

        UpdateUI();
    }

    private async void UpdateUI()
    {
        Projects = new ObservableCollection<Project>( await _projectService.GetAll());
        Employees = await _projectService.GetEmployees();
    }

    private bool CanRemove() => SelectedItem is not null && SelectedItem.Id > 0;
    [RelayCommand( CanExecute = nameof(CanRemove))]
    private void Remove(int id)
    {
        if(!CanRemove()) 
            return;

        _projectService.Remove(id);

        UpdateUI();
    }

    private bool CanAdd() => SelectedItem is not null;
    [RelayCommand( CanExecute = nameof(CanAdd))]
    private void Add(Project project)
    {
        if(!CanAdd()) 
            return;

        _projectService.AddOrUpdate(project);

        TogglePopUp();

        UpdateUI();
    }

    [RelayCommand]
    private void ToggleAddPopUp()
    {
        SelectedItem = new Project { 
            Name = ""
        };

        ShowPopUp = !ShowPopUp;
    }

    [RelayCommand]
    private void TogglePopUp()
    {
        ShowPopUp = !ShowPopUp;
    }

    private bool CanToggleEdit() => SelectedItem is not null && SelectedItem.Id > 0;
    [RelayCommand(CanExecute = nameof(CanToggleEdit))]
    private void ToggleEditPopUp()
    {
        if (!CanToggleEdit())
            return;

        ShowPopUp = !ShowPopUp;
    }
}
