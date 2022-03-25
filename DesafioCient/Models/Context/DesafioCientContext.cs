using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCient.Models.Context
{
    public class DesafioCientContext : DbContext
    {

        public DesafioCientContext(DbContextOptions<DesafioCientContext> options): base(options)
        {
                
        }

        public DbSet<Empresa> Empresas { get; set; }

    }
}
