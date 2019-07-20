using CoreFaces.Region.Models.Domain;
using CoreFaces.Region.Models.Models;
using CoreFaces.Region.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.Services
{

    public interface IRegionSchemaService  
    {
        bool DropTables();
        bool EnsureCreated();
    }

    public class RegionSchemaService : IRegionSchemaService
    {
        private readonly IRegionSchemaRepository regionSchemaRepository;
        public RegionSchemaService(RegionDatabaseContext regionDatabaseContext, IOptions<RegionSettings> regionSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            this.regionSchemaRepository = new RegionSchemaRepository(regionDatabaseContext, regionSettings, iHttpContextAccessor);
        }


        public bool DropTables()
        {
            return regionSchemaRepository.DropTables();
        }

        public bool EnsureCreated()
        {
            return regionSchemaRepository.EnsureCreated();
        }
    }

}
