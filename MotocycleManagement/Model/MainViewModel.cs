using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using MotocycleManagement.Domain.Models;
using MotocycleManagement.WPF.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotocycleManagement.WPF.Model;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Domain.Models.MotocycleModel>? _items;

    [ObservableProperty]
    private Domain.Models.MotocycleModel? _selectedItem;

    [ObservableProperty]
    private Brand? _selectedBrand;
    [ObservableProperty]
    private Brand[] _brands;

    [ObservableProperty]
    private string _name; 
    [ObservableProperty]
    private int _productionYear; 
    [ObservableProperty]
    private Guid _brandId;

    [ObservableProperty]
    private bool _showPopUp = false;

    private readonly IMotocycleController _controller;
    public MainViewModel(IServiceProvider serviceProvider)
    {
        _controller = serviceProvider.GetRequiredService<IMotocycleController>();
        Brands = GetBrands();

        Refresh();
    }

    [RelayCommand]
    private void Refresh()
    {
        if (Items is null)
        {
            Items = _controller.GetMotocycles();
            return;
        }
        Items = _controller.GetMotocycles();
    }

    [RelayCommand]
    private void AddOrUpdate()
    {
        if (SelectedItem is not null)
        {
            _controller.AddOrUpdate(
                SelectedItem with { 
                    Id = SelectedItem.Id,
                    Brand = SelectedBrand,
                    Name = Name,
                    ProductionYear = ProductionYear
                });
            ToggelPopUp();
            SelectedItem = null;
            return;
        }

        _controller.AddOrUpdate(new Domain.Models.MotocycleModel
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Brand = SelectedBrand,
            ProductionYear = ProductionYear
        });

        ToggelPopUp();

    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedItem is null)
            return;

        _controller.Remove(SelectedItem.Id);
    }

    [RelayCommand]
    private void ToggelPopUp()
    {
        ShowPopUp = !ShowPopUp;
        if (SelectedItem is not null)
        {
            Name = SelectedItem.Name;
            ProductionYear = SelectedItem.ProductionYear;
            BrandId = SelectedItem.BrandId;
        }
    }

    private Brand[] GetBrands() => _controller.GetBrands();
}
