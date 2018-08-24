using AutoMapper;
using DDD.Domain.Core.Interfaces.Entities;
using DDD.Domain.Core.Interfaces.Repositories;
using DDD.Domain.Core.Interfaces.Services;
using DDD.Infra.Cross.DomainDriver;
using DDD.Infra.Cross.DomainDriver.Attributes;
using DDD.Infra.Cross.DomainDriver.Extensions;
using DDD.Infra.Cross.DomainDriver.Mvc.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace MentalClean.UI.Questionario.Controllers
{
    public class GenericMVCController : ControllerBase
    {
        private readonly IGenericRepositoryReadByName repositoryRead;
        private readonly IGenericDomainService service;
        private readonly IUnitOfWork uoW;

        public GenericMVCController(
            IGenericRepositoryRead repositoryRead,
            IGenericDomainService service,
            IUnitOfWork uoW)
            : base()
        {
            this.repositoryRead = repositoryRead;
            this.service = service;
            this.uoW = uoW;
        }

        //[HttpGet("")]
        //public IActionResult Index()
        //{
        //    return Ok("api inicializada");
        //}

        [ObjectNameFilter("pessoa")]
        [HttpGet("{objectName}")]
        public IActionResult List(string objectName)
        {
            ModelState.Clear();

            var entidades = repositoryRead.GetAll(objectName);

            var tipoModel = Driver.GetRefType("ViewModel", objectName, DriverAction.GetAll);

            var models = Mapper.Map(entidades, entidades.GetType(), typeof(IEnumerable<>).MakeGenericType(tipoModel));

            var viewName = $"{objectName}/List";
            return View(viewName, models);
        }

        [HttpGet("{objectName}/new")]
        public IActionResult New(string objectName)
        {
            var tipoModel = Driver.GetRefType("ViewModel", objectName, DriverAction.GetSingle);

            var model = tipoModel.CreateInstance();

            var viewName = $"{objectName}/New";
            return View(viewName, model);
        }

        [HttpPost("{objectName}/new")]
        public IActionResult New(string objectName, IFormCollection form)
        {
            ModelState.Clear();
            var domainType = Driver.GetDomainType(objectName);

            var vmType = Driver.GetRefType("ViewModel", domainType, DriverAction.Insert);

            if (vmType == null)
                return NotFound();

            var model = BindModel(form, vmType);

            var viewName = $"{objectName}New";

            if (!TryValidateModel(model))
                return View(viewName, model);

            var entity = Mapper.Map(model, model.GetType(), domainType) as IDefaultEntity;
            service.Add(entity);
            uoW.SaveChanges();

            return RedirectToAction("List", new { objectName });
        }

        [HttpGet("{objectName}/{id}")]
        public IActionResult Edit(string objectName, Guid id)
        {
            ModelState.Clear();

            var entidade = repositoryRead.GetSingle(objectName, id);

            var tipoModel = Driver.GetRefType("ViewModel", objectName, DriverAction.Update);

            var model = Mapper.Map(entidade, entidade.GetType(), tipoModel);

            var viewName = $"{objectName}/Edit";
            return View(viewName, model);
        }

        [HttpPost("{objectName}/{id}")]
        public IActionResult Edit(string objectName, Guid id, IFormCollection form)
        {
            ModelState.Clear();
            var domainType = Driver.GetDomainType(objectName);

            var vmType = Driver.GetRefType("ViewModel", domainType, DriverAction.Update);
            if (vmType == null)
                return NotFound();

            var model = BindModel(form, vmType);

            if (!TryValidateModel(model))
            {
                var viewName = $"{objectName}/Edit";
                return View(viewName, model);
            }

            var entity = repositoryRead.GetSingle(objectName, id) as IDefaultEntity;
            Mapper.Map(model, entity, vmType, domainType);
            service.Update(entity);
            uoW.SaveChanges();

            return RedirectToAction("List", new { objectName });
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
