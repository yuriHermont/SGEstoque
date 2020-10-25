using Microsoft.EntityFrameworkCore;
using SGE.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Infrastructure.Repository.Context
{
    public class EfContext : DbContext
    {
        public DbSet<Produto> Cliente { get; set; }
    }
}
