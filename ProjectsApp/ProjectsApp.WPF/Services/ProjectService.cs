using Microsoft.EntityFrameworkCore;
using ProjectsApp.Domain;
using ProjectsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsApp.WPF.Services;

public interface IProjectService
{
   Task<IEnumerable<Project>> GetAll();
   Task<IEnumerable<Employee>> GetEmployees();
    Task<bool> Remove(int id);

    Task AddOrUpdate(Project project);
}

public class ProjectService : IProjectService
{
    public async Task AddOrUpdate(Project project)
    {
        var item = await AppDbContext.Get.Projects.FindAsync(project.Id);
        if (item is null)
        {
            AppDbContext.Get.Add(project);
        }else
        {
            AppDbContext.Get.Remove(item);
            await AppDbContext.Get.Projects.AddAsync(project);
        }
       
            await AppDbContext.Get.SaveChangesAsync();
    }

    public async Task<IEnumerable<Project>> GetAll()
    {
        var result = await AppDbContext.Get
            .Projects
            .ToListAsync();

        return result;
    }

    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        var result = await AppDbContext.Get
            .Employees
            .ToListAsync();

        return result;
    }

    public async Task<bool> Remove(int id)
    {
        var item = await AppDbContext.Get.Projects.FindAsync(id);
        if (item is null)
            return false;

        AppDbContext.Get.Projects.Remove(item);
        await AppDbContext.Get.SaveChangesAsync();
        return true;
    }
}
