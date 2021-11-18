using AutoMapper;
using HomeAutomationCentral.Models;
using HomeAutomationCentral.Domain;
using HomeAutomationCentral.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomationCentral.Business.Services.Contracts
{
    public class AreaService : IAreaService
    {
        IMapper _mapper;

        HomeAutomationCentralDbContext _dbContext;

        public AreaService(HomeAutomationCentralDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool UpdateArea(AreaModel areaModel)
        {
            try
            {
                var area = _mapper.Map<Area>(areaModel);
                _dbContext.Areas.Update(area);
                var result = _dbContext.SaveChanges();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public AreaModel GetAreaDetails(int id)
        {
            var area = _dbContext.Areas.Single(s => s.AreaId == id);
            var areaModel = _mapper.Map<AreaModel>(area);

            return areaModel;

        }

        public List<AreaModel> GetAreas()
        {
            try
            {
                var areaList = new List<AreaModel>();
                var areas = _dbContext.Areas.ToList();
                foreach (var area in areas)
                {
                    if (area.Name != null)
                    {
                        var areaModel = _mapper.Map<AreaModel>(area);
                        areaList.Add(areaModel);
                    }
                    else
                    { 
                        _dbContext.Remove(area);
                    }
                }
                return areaList;
            }
            catch
            {
                return new List<AreaModel>();
            }
        }

        public bool CreateArea(AreaModel areaModel)
        {
            try
            {
                var area = _mapper.Map<Area>(areaModel);
                _dbContext.Areas.Add(area);
                var result = _dbContext.SaveChanges();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAreaById(int id)
        {
            try
            {
                Area area = new Area() { AreaId = id };
                _dbContext.Areas.Remove(area);
                var result = _dbContext.SaveChanges();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public AreaModel EditArea(int id, AreaModel areaModel)
        {
            try
            {
                var area = _mapper.Map<Area>(areaModel);
                var entity = _dbContext.Areas.FirstOrDefault(e => e.AreaId == id);
                entity.Name = area.Name;
                entity.HostId = area.HostId;
                entity.Devices = area.Devices;

                _dbContext.Update(entity);
                var result = _dbContext.SaveChanges();
                var output = GetAreaDetails(id);

                return output;
            }
            catch (Exception e)
            {
                return new AreaModel();
            }
        }

        public List<DeviceModel> GetDevicesByAreaId(int id)
        {
            try
            {
                var entity = _mapper.Map<List<DeviceModel>>(_dbContext.Areas.FirstOrDefault(e => e.AreaId == id).Devices);
                
                return entity;
            }
            catch (Exception e)
            {
                return new List<DeviceModel>();
            }
        }
    }
}
