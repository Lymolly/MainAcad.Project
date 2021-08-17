using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTOs;
using Airline.BLL.Services;
using AirlineProj.Configuration;
using AirlineProj.Models.CreateViewModels;
using AirlineProj.Models.InfosViewModels;
using AutoMapper;

namespace AirlineProj.Controllers
{
    public class AirlineController : Controller
    {
        InfoService iService;
        private static MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperConfigProfile()));
        private static Mapper mapper = new Mapper(config);
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

        public ActionResult CheapestFlight()
        {
            var info = iService.GetAll().OrderBy(m => m.Price).FirstOrDefault();
            if (info != null)
            {
                var mapper = new Mapper(config);
                var res = mapper.Map<InfoViewModel>(info);
                return PartialView(res);
            }
            return HttpNotFound();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Buy(int? id)
        {
            if (id.HasValue)
            {
                var info = await iService.GetById(id.Value);
                var res = mapper.Map<InfoViewModel>(info);
                //ViewData["Model"] = res;
                //var a = (InfoViewModel)ViewData["Model"];
                return View(res);
            }

            return HttpNotFound();
        }
        [HttpPost]
        [ActionName("Buy")]
        [Authorize]
        public async Task<ActionResult> ConfirmBuy(int? modelId,string gender)
        {
            var model = await iService.GetById(modelId.Value);
            var data = mapper.Map<CreateInfoViewModel>(model);
            if (data.Plane.Capacity - data.Passengers.Count() >=1)
            {
                data.Passengers.Add(new CreatePassengerViewModel
                {
                    FullName = User.Identity.Name,
                    Gender = gender,
                    Age = 18,
                    FlightInfo = data
                });
                var mod = mapper.Map<InfoDTO>(data);
                await iService.UpdatePassengerInfo(mod);
                ViewBag.Succed = $"You`re registered to {data.Route.Destination}, plane arrives at {data.ArrivalTime}, and leaves at {data.DepartureTime}";
                return RedirectToAction("AllInfo");
            }
            ModelState.AddModelError("","No places in plane!");
            return RedirectToAction("Buy");
        }

        public ActionResult Search(string substr)
        {
            if (!string.IsNullOrWhiteSpace(substr))
            {
                var allFlights = mapper.Map<List<InfoViewModel>>(iService.GetAll().Where(i => i.Route.To.Contains(substr)));
                if (allFlights == null || allFlights.Count() <= 0)
                {
                    return HttpNotFound();
                }
                return PartialView(allFlights);
            }
            ModelState.AddModelError("", "Enter the city");
            return RedirectToRoute("AllInfo");
        }
    }
}