using CoreFaces.Region.Models.Models;
using CoreFaces.Region.Repositories;
using CoreFaces.Region.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFaces.Region.UnitTest
{
    public class BaseTest
    {
        public RegionDatabaseContext _regionDatabaseContext;
        public readonly IRegionSchemaService regionSchemaService;
        public readonly ICityService _cityService;


        public BaseTest()
        {
            // var serviceProvider = new ServiceCollection()
            ////.AddEntityFrameworkSqlServer()
            //.AddEntityFrameworkNpgsql()
            //.AddTransient<ITestService, TestService>()
            //.BuildServiceProvider();

            DbContextOptionsBuilder<RegionDatabaseContext> builder = new DbContextOptionsBuilder<RegionDatabaseContext>();
            var connectionString = "server=localhost;userid=root;password=12345678;database=CityDatabase;";
            builder.UseMySql(connectionString);
            //.UseInternalServiceProvider(serviceProvider); //burası postgress ile sıkıntı çıkartmıyor, fakat mysql'de çalışmıyor test esnasında hata veriyor.

            _regionDatabaseContext = new RegionDatabaseContext(builder.Options);
            //_context.Database.Migrate();

            RegionSettings _regionSettings = new RegionSettings() { FileUploadFolderPath = "c:/" };
            IOptions<RegionSettings> regionOptions = Options.Create(_regionSettings);
            IHttpContextAccessor iHttpContextAccessor = new HttpContextAccessor { HttpContext = new DefaultHttpContext() };

            _cityService = new CityService(_regionDatabaseContext, regionOptions, iHttpContextAccessor);
            regionSchemaService = new RegionSchemaService(_regionDatabaseContext, regionOptions, iHttpContextAccessor);

        }
    }
}
