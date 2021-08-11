using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.Services;
using AirlineProj.Configuration;
using AirlineProj.Models.InfosViewModels;
using AutoMapper;

namespace AirlineProj.Controllers
{
    public class AirlineController : Controller
    {
        InfoService iService;
        private MapperConfiguration config =
            new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfigProfile()));
        public AirlineController()
        {
            iService = new InfoService();
        }
        // GET: Airline
        public ActionResult AllInfo()
        {
            var infos = iService.GetAll();
            var mapper = new Mapper(config);
            var res = mapper.Map<IEnumerable<InfoViewModel>>(infos);
            return View(res);
        }
    }
}