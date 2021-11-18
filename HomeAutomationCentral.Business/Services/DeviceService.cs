using AutoMapper;
using HomeAutomationCentral.Models;
using HomeAutomationCentral.Domain;
using HomeAutomationCentral.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeAutomationCentral.Business.Services.Contracts
{
    public class DeviceService : IDeviceService
    {
        IMapper _mapper;
        HomeAutomationCentralDbContext _dbContext;
        public DeviceService(HomeAutomationCentralDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<DeviceModel> GetDevices()
        {
            try
            {
                var deviceList = new List<DeviceModel>();
                var devices = _dbContext.Device.ToList();
                foreach (var device in devices)
                {
                    if (device.Name != null)
                    {
                        DeviceModel devicesModel = _mapper.Map<DeviceModel>(device);
                        deviceList.Add(devicesModel);
                    }
                }    
                return deviceList;
            }
            catch
            {
                return new List<DeviceModel>();
            }
        }
        public void UpdateDevices(List<DeviceModel> devices)
        {
            foreach (var deviceModel in devices)
            {
                var device = _mapper.Map<Device>(deviceModel);
                _dbContext.Device.Update(device);
            }
        }

        public DeviceModel GetDeviceDetails(int id)
        {
            var result = _dbContext.Device.Single(s => s.Id == id);
            var device = _mapper.Map<DeviceModel>(result);
            return device;
        }

        public bool CreateDevice(DeviceModel deviceModel)
        {
            try
            {
                
                var device = _mapper.Map<Device>(deviceModel);
                device.AreaId = null;
                _dbContext.Device.Add(device);
                var result = _dbContext.SaveChanges();

                return result > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteDevice(int id)
        {
            try
            {
                Device device = new Device() { Id = id };
                _dbContext.Device.Remove(device);
                var result = _dbContext.SaveChanges();

                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public DeviceModel EditDevice(int id, DeviceModel deviceModel)
        {

            Device entity = _dbContext.Device.FirstOrDefault(e => e.Id == id);
            //var device = _mapper.Map<DeviceModel>(entity);
            //device = deviceModel;
            //_dbContext.Entry(entity).State = EntityState.Detached;
            var  newEntity = _mapper.Map(deviceModel, entity);
            newEntity.AreaId = deviceModel.AreaId;
            _dbContext.Update(newEntity);
            _dbContext.SaveChanges();
            var result = GetDeviceDetails(id);

            return result;
        }
    }
}
