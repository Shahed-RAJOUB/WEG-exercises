﻿using Microsoft.EntityFrameworkCore;
using MyApp.Entities;

namespace MyApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppMember> Members { get; set; }
    }
}