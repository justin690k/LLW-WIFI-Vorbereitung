using MotocycleManagement.Domain;
using MotocycleManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotocycleManagement.WPF.Controller;

public interface IMotocycleController
{
    void AddOrUpdate(Domain.Models.MotocycleModel model);
    bool Remove(Guid id);
    ObservableCollection<Domain.Models.MotocycleModel> GetMotocycles();
    Brand[] GetBrands();
}

public class MotocycleController : IMotocycleController
{
    private AppDbContext? _context;
    public MotocycleController()
    {
        _context = AppDbContext.Get;
    }

    public void AddOrUpdate(Domain.Models.MotocycleModel model)
    {
        var item = _context.Models.Find(model.Id);
        if (item is null)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                _context.Add(model);
                _context.SaveChanges();
                return;
            }
            return;
        }

        _context.Models.Remove(item);
        _context.Models.Add(
            item with 
            { 
                Id = model.Id,
                Name = model.Name,
                ProductionYear = model.ProductionYear,
                Brand = model.Brand,
            });
        
        _context.SaveChanges();
    }

    public Brand[] GetBrands()
    {
        if (_context is null)
            return [];

        var result = _context.Brands
            .ToArray();
        return result;
    }

    public ObservableCollection<Domain.Models.MotocycleModel> GetMotocycles()
    {
        if (_context is null)
            return new ObservableCollection<Domain.Models.MotocycleModel>(Array.Empty<Domain.Models.MotocycleModel>());

        var result = _context.Models
            .ToList();
        return new ObservableCollection<Domain.Models.MotocycleModel>((IEnumerable<MotocycleModel>)result);
    }

    public bool Remove(Guid id)
    {
        var items = _context.Models.ToList();
        var item = items.FirstOrDefault(x => x.Id.Equals(id));
        if (item is null)
            return false;
        _context.Models.Remove(item);
        _context.SaveChanges();
        return true;
    }
}
