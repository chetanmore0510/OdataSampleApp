
using Domain.Data.Configurations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
namespace Domain.Data
{
    public partial class SamplesContext : DbContext
    {
        public virtual DbSet<EditorData> EditorData { get; set; } = null!;
        public virtual DbSet<Location> Location { get; set; } = null!;
        public virtual DbSet<Tasks> Tasks { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;

        public SamplesContext(DbContextOptions<SamplesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.EditorDataConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.LocationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TasksConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UsersConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
