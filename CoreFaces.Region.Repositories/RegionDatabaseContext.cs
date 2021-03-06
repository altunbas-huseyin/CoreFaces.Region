﻿using CoreFaces.Region.Models.Domain;
using CoreFaces.Region.Models.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CoreFaces.Region.Repositories
{
   public class RegionDatabaseContext : DbContext
    {
        public RegionDatabaseContext(DbContextOptions<RegionDatabaseContext> options) : base(options)
        {
            //bool status = this.Database.EnsureDeleted();
            //IExecutionStrategy dd = this.Database.CreateExecutionStrategy();
            //bool test = this.Database.EnsureCreated();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CityMap(modelBuilder.Entity<City>());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        private void AddTimestamps()
        {
            var changeSet = ChangeTracker.Entries<EntityBase>();
            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.UpdateDate = DateTime.Now;
                        entry.Entity.CreateDate = DateTime.Now;
                    }
                    entry.Entity.UpdateDate = DateTime.Now;
                }
            }
        }

    }
}
