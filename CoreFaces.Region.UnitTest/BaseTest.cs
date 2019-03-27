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
        public RegionDatabaseContext _statusDatabaseContext;

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

            _statusDatabaseContext = new RegionDatabaseContext(builder.Options);
            //_context.Database.Migrate();

            CitySettings _statusSettings = new CitySettings() { FileUploadFolderPath = "c:/" };
            IOptions<CitySettings> statusOptions = Options.Create(_statusSettings);
            IHttpContextAccessor iHttpContextAccessor = new HttpContextAccessor { HttpContext = new DefaultHttpContext() };

            _cityService = new CityService(_statusDatabaseContext, statusOptions, iHttpContextAccessor);

        }
    }
}
