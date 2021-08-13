using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.Services;
using AirlineProj.Configuration;
using AirlineProj.Models.InfosViewModels;
using AutoMapper;

namespace AirlineProj.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        InfoService iService;
        private MapperConfiguration config =
            new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfigProfile()));
        public AdminController()
        {
            iService = new InfoService();
        }
        // GET: Airline
        public ActionResult AdminIndex()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var infos = await iService.GetById(id);
            var mapper = new Mapper(config);
            var res = mapper.Map<InfoViewModel>(infos);
            return View(res);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(InfoViewModel model)
        {
            return View();
        }
    }
}