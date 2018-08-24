using AutoMapper;
using DDD.Domain.Core.Interfaces.Entities;
using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using DDD.Infra.Cross.DomainDriver;
using DDD.Infra.Cross.DomainDriver.Attributes;
using DDD.Infra.Cross.DomainDriver.Extensions;
using DDD.Infra.Cross.DomainDriver.Mvc.Attributes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MentalClean.UI.Questionario.Controllers
{
    [Route("api")]
    public class GenericController : ControllerBase
    {
        private readonly IGenericRepositoryReadByName repositoryRead;
        private readonly IGenericDomainService service;
        private readonly IUnitOfWork uoW;

        public GenericController(
            IGenericRepositoryRead repositoryRead,
            IGenericDomainService service,
            IUnitOfWork uoW)
            : base()
        {
            this.repositoryRead = repositoryRead;
            this.service = service;
            this.uoW = uoW;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok("api inicializada");
        }

        [ObjectNameFilter("pessoa")]
        [HttpGet("{objectName}")]
        public IActionResult Get(string objectName)
        {
            ModelState.Clear();

            var entidades = repositoryRead.GetAll(objectName);

            var tipoModel = Driver.GetRefType("ViewModel", objectName, DriverAction.GetAll);

            if (tipoModel == null)
                return ResponseApi(entidades);

            var models = Mapper.Map(entidades, entidades.GetType(), typeof(IEnumerable<>).MakeGenericType(tipoModel));
            return ResponseApi(models);
        }

        [HttpGet("{objectName}/{id}")]
        public IActionResult Get(string objectName, Guid id)
        {
            ModelState.Clear();

            var entidade = repositoryRead.GetSingle(objectName, id);

            var tipoModel = Driver.GetRefType("ViewModel", objectName, DriverAction.GetSingle);

            if (tipoModel == null)
                return ResponseApi(entidade);

            var model = Mapper.Map(entidade, entidade.GetType(), tipoModel);
            return ResponseApi(model);
        }

        [HttpPost("{objectName}")]
        public IActionResult Post(string objectName, [FromBody] object value)
        {
            ModelState.Clear();

            var vmType = Driver.GetRefType("ViewModel", objectName, DriverAction.Insert);
            if (vmType == null)
                return NotFound();

            var domainType = Driver.GetDomainType(objectName);
            var stringJsonObject = JsonConvert.SerializeObject(value);
            var model = JsonConvert.DeserializeObject(stringJsonObject, vmType);

            if (TryValidateModel(model))
            {
                var entity = JsonConvert.DeserializeObject(stringJsonObject, domainType) as IDefaultEntity;
                service.Add(entity);
                uoW.SaveChanges();
            }

            return ResponseApi(model);
        }

        [HttpPost("{objectName}/lot")]
        public IActionResult PostLot(string objectName, [FromBody] object value)
        {
            ModelState.Clear();
            var domainType = Driver.GetDomainType(objectName);

            var vmType = Driver.GetRefType("ViewModel", domainType, DriverAction.Insert);
            if (vmType == null)
                return NotFound();

            var models = BindModel(value, vmType) as IEnumerable<object>;

            foreach (var model in models)
            {
                if (!TryValidateModel(model))
                    return ResponseApi(models);

                var entity = domainType.CreateInstance();
                Mapper.Map(model, entity, vmType, domainType);
                service.Add(entity as IDefaultEntity);
            }

            uoW.SaveChanges();
            return Ok(models);
        }

        [HttpPut("{objectName}/{id}")]
        public IActionResult Put(string objectName, Guid id, [FromBody] object value)
        {
            ModelState.Clear();
            var domainType = Driver.GetDomainType(objectName);

            var vmType = Driver.GetRefType("ViewModel", domainType, DriverAction.Update);
            if (vmType == null)
                return NotFound();

            var model = BindModel(value, vmType);

            if (TryValidateModel(model))
            {
                var entity = repositoryRead.GetSingle(objectName, id) as IDefaultEntity;
                Mapper.Map(model, entity, vmType, domainType);
                service.Update(entity);
                uoW.SaveChanges();
            }

            return ResponseApi(model);
        }

        [HttpPut("{objectName}/lot")]
        public IActionResult Put(string objectName, [FromBody] object value)
        {
            ModelState.Clear();
            var domainType = Driver.GetDomainType(objectName);

            var vmType = Driver.GetRefType("ViewModel", domainType, DriverAction.Update);
            if (vmType == null)
                return NotFound();

            var models = BindModel(value, vmType) as IEnumerable<object>;

            foreach (var model in models)
            {
                if (!TryValidateModel(model))
                    return ResponseApi(models);

                var entity = repositoryRead.GetSingle(objectName, (model as IId).GetId()) as IDefaultEntity;
                Mapper.Map(model, entity, vmType, domainType);
                service.Update(entity);
                uoW.SaveChanges();
            }

            return ResponseApi(models);
        }

        [HttpDelete("{objectName}/{id}")]
        public IActionResult Delete(string objectName, Guid id)
        {
            ModelState.Clear();

            var type = Driver.GetDomainType(objectName);
            service.Delete(type, id);
            uoW.SaveChanges();
            return ResponseApi(id);
        }
    }
}
