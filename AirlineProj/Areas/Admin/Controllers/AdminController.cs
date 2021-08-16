using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTOs;
using Airline.BLL.Services;
using AirlineProj.Configuration;
using AirlineProj.ModelBinder;
using AirlineProj.Models.InfosViewModels;
using AutoMapper;

namespace AirlineProj.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        InfoService iService;
        private PlaneService planeService;
        private MapperConfiguration config =
            new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfigProfile()));
        public AdminController()
        {
            iService = new InfoService();
            planeService = new PlaneService();
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


            SelectList st = new SelectList(Statuses());
            ViewBag.Statuses = st;
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(InfoViewModel model)
        {
            var mapper = new Mapper(config);
            var res = mapper.Map<InfoDTO>(model);
            await iService.UpdateInfo(res);
            return RedirectToAction("AllInfo", "Airline",new {area = ""});
        }

        [HttpGet]
        public ActionResult CreateNew()
        {
            SelectList st = new SelectList(Statuses());
            ViewBag.Statuses = st;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNew(CreateInfoViewModel model)
        {
            var mapper = new Mapper(config);
            if (ModelState.IsValid)
            {
                await iService.AddNewInfo(mapper.Map<InfoDTO>(model));
                return RedirectToAction("AllInfo", "Airline", new { area = "" });
            }
            return View(model);
        }
        //[HttpPost]
        //public async Task<ActionResult> EditPlane(InfoViewModel model)
        //{
        //    var mapper = new Mapper(config);
        //    var res = mapper.Map<PlaneDTO>(model.Plane);
        //    await planeService.UpdatePlane(res);
        //    return View("Edit");
        //}

        private IEnumerable<string> Statuses()
        {
            return new List<string>
            {
                "Arriving",
                "Scheduled",
                "Redirected",
                "Landed",
                "Diverted",
                "Cancelled",
                "Unknown"
            };
        }
    }
}