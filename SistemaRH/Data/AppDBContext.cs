using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaRH.Models;

namespace SistemaRH.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaRH.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<SistemaRH.Models.Empresa> Empresa { get; set; } = default!;
        public DbSet<SistemaRH.Models.Tarefa> Tarefa { get; set; } = default!;
        public DbSet<SistemaRH.Models.Departamento> Departamento { get; set; } = default!;
    }
}
