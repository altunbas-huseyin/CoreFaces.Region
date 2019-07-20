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

    public interface ICityService : IBaseService<City>
    {
        List<Models.Domain.City> GetByTitle(string title);
        List<Models.Domain.City> GetAll();
    }

    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(RegionDatabaseContext databaseContext, IOptions<RegionSettings> statusSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            _cityRepository = new CityRepository(databaseContext, statusSettings, iHttpContextAccessor);
        }

        public Models.Domain.City GetById(int id)
        {
            return _cityRepository.GetById(id);
        }

        public int Save(Models.Domain.City status)
        {
            _cityRepository.Save(status);
            return status.Id;
        }

        public bool Delete(int id)
        {
            return _cityRepository.Delete(id);
        }

        public bool Update(Models.Domain.City status)
        {
            return _cityRepository.Update(status);

        }

        public List<Models.Domain.City> GetByTitle(string title)
        {
            return _cityRepository.GetByTitle(title);
        }

        public List<Models.Domain.City> GetAll()
        {
            return _cityRepository.GetAll();
        }

        public bool DropTables()
        {
            return _cityRepository.DropTables();
        }

        public bool EnsureCreated()
        {
            return _cityRepository.EnsureCreated();
        }
    }

}
