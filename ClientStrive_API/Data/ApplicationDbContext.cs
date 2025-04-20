using System;
using ClientStrive_API.Migrations;
using ClientStrive_API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientStrive_API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }  

    public DbSet<Role> Roles { get; set; }

    public DbSet<Designation> Designations { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<ClientProject> ClientProjects { get; set; }
}
