using CoreFaces.Licensing;
using CoreFaces.Region.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreFaces.Region.Repositories
{

    public interface ICityRepository : IBaseRepository<Models.Domain.City>
    {
        List<Models.Domain.City> GetByTitle(string name);
        List<Models.Domain.City> GetAll();
    }
    public class CityRepository : Licence, ICityRepository
    {

        private readonly RegionDatabaseContext _databaseContext;

        public CityRepository(RegionDatabaseContext databaseContext, IOptions<RegionSettings> statusSettings, IHttpContextAccessor iHttpContextAccessor) : base("City", iHttpContextAccessor, statusSettings.Value.CityLicenseDomain, statusSettings.Value.CityLicenseKey)
        {
            _databaseContext = databaseContext;
        }

        public bool Delete(int id)
        {
            Models.Domain.City model = this.GetById(id);
            _databaseContext.Remove(model);
            int result = _databaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }

        public List<Models.Domain.City> GetByTitle(string title)
        {
            List<Models.Domain.City> model = _databaseContext.Set<Models.Domain.City>().Where(p => p.Title == title).ToList();
            return model;
        }

        public Models.Domain.City GetById(int id)
        {
            Models.Domain.City model = _databaseContext.Set<Models.Domain.City>().Where(p => p.Id == id).FirstOrDefault();
            return model;
        }

        public int Save(Models.Domain.City status)
        {
            _databaseContext.Add(status);
            _databaseContext.SaveChanges();
            return status.Id;
        }

        public bool Update(Models.Domain.City status)
        {
            _databaseContext.Update(status);
            int result = _databaseContext.SaveChanges();
            return Convert.ToBoolean(result);
        }

        public List<Models.Domain.City> GetAll()
        {
            return _databaseContext.Set<Models.Domain.City>().ToList();
        }

        public bool DropTables()
        {
            int result = _databaseContext.Database.ExecuteSqlCommand("DROP TABLE City;");
            if (result == 0)
                return true;
            else
                return false;
        }

        public bool EnsureCreated()
        {
            RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)_databaseContext.Database.GetService<IDatabaseCreator>();
            databaseCreator.CreateTables();
            return true;
        }
    }


}
