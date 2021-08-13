using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTOs;
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

        public async Task<ActionResult> Details(int? id)
        {
            if (id.HasValue)
            {
                var info = await iService.GetById(id.Value);
                var mapper = new Mapper(config);
                var res = mapper.Map<InfoViewModel>(info);
                return PartialView(res);
            }
            return HttpNotFound();
        }

        [HttpGet]
        public async Task<ActionResult> Buy(int? id)
        {
            if (id.HasValue)
            {
                var info = await iService.GetById(id.Value);
                var mapper = new Mapper(config);
                var res = mapper.Map<InfoViewModel>(info);
                return View(res);
            }

            return HttpNotFound();
        }
        [HttpPost]
        [ActionName("Buy")]
        public async Task<ActionResult> ConfirmBuy(InfoViewModel model)
        {
            if (model.Plane.Capacity - model.Passengers.Count() >=1)
            {
                model.Passengers.Add(new PassengerViewModel
                {
                    FullName = User.Identity.Name,
                });
                var mapper = new Mapper(config);
                var res = mapper.Map<InfoDTO>(model);
                await iService.UpdateInfo(res);
                ViewBag.Succed = $"You`re registered to {model.Route.Destination}, plane arrives at {model.ArrivalTime}, and leaves at {model.DepartureTime}";
                return RedirectToAction("AllInfo");
            }
            ModelState.AddModelError("", "No places for this flight(");
            return View("Buy",model);
        }
    }
}