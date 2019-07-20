using CoreFaces.Region.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.Repositories
{
    public interface IRegionSchemaRepository
    {
        bool DropTables();
        bool EnsureCreated();
    }
    public class RegionSchemaRepository : IRegionSchemaRepository
    {
        private readonly RegionDatabaseContext _RegionDatabaseContext;

        public RegionSchemaRepository(RegionDatabaseContext RegionDatabaseContext, IOptions<RegionSettings> regionSettings, IHttpContextAccessor iHttpContextAccessor) 
        {
            _RegionDatabaseContext = RegionDatabaseContext;
        }

        public bool DropTables()
        {
            int result = _RegionDatabaseContext.Database.ExecuteSqlCommand("DROP TABLE `City`;");
            if (result == 0)
                return true;
            else
                return false;
        }

        public bool EnsureCreated()
        {
            RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)_RegionDatabaseContext.Database.GetService<IDatabaseCreator>();
            databaseCreator.CreateTables();
            return true;
        }

    }
}
