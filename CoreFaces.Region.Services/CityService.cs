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
        private readonly ICityRepository _statusRepository;
        public CityService(RegionDatabaseContext databaseContext, IOptions<CitySettings> statusSettings, IHttpContextAccessor iHttpContextAccessor)
        {
            _statusRepository = new CityRepository(databaseContext, statusSettings, iHttpContextAccessor);
        }

        public Models.Domain.City GetById(int id)
        {
            return _statusRepository.GetById(id);
        }

        public int Save(Models.Domain.City status)
        {
            _statusRepository.Save(status);
            return status.Id;
        }

        public bool Delete(int id)
        {
            return _statusRepository.Delete(id);
        }

        public bool Update(Models.Domain.City status)
        {
            return _statusRepository.Update(status);

        }

        public List<Models.Domain.City> GetByTitle(string title)
        {
            return _statusRepository.GetByTitle(title);
        }

        public List<Models.Domain.City> GetAll()
        {
            return _statusRepository.GetAll();
        }

        public bool DropTables()
        {
            return _statusRepository.DropTables();
        }

        public bool EnsureCreated()
        {
            return _statusRepository.EnsureCreated();
        }
    }

}
