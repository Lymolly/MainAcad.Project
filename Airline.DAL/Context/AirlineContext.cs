using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.Domain.Entities;

namespace Airline.DAL.Context
{
    public class AirlineContext : DbContext
    {
        public AirlineContext() : base("AirlineDB")
        {
            Database.SetInitializer(new AirlineDbInitializer());
        }

        public DbSet<Info> Infos { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Way> Ways { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<FlightStatus> Statuses { get; set; }
    }

    public class AirlineDbInitializer : DropCreateDatabaseAlways<AirlineContext>
    {
        protected override void Seed(AirlineContext context)
        {
            //Way
            var way = new Way() { Length = "700km", Time = "3 hours" };
            //Passengers
            var passenger1 = new Passenger { Age = 20, FullName = "Vasya Petya", Gender = "Male" };
            var passenger2 = new Passenger { Age = 25, FullName = "dasds", Gender = "Female" };
            var passenger3 = new Passenger { Age = 19, FullName = "Allah", Gender = "Male" };
            var passenger4 = new Passenger { Age = 43, FullName = "Akbar", Gender = "Male" };

            List<Passenger> passes = new List<Passenger>
            {
                passenger1, passenger2, passenger3, passenger4
            };
            //Plane
            var plane = new Plane
                { Model = "Airbus 737", Capacity = 200, PlaneNumber = "44AC", Speed = 500, Wingspan = 250, Way = way, Passengers = passes };
            //Status
            var status = new FlightStatus { Status = "Arriving" };

            //Add to contet & save
            context.Planes.Add(plane);
            context.Ways.Add(way);
            context.Statuses.Add(status);
            context.Passengers.AddRange(passes);
            context.SaveChanges();
            //Info
            var info = new Info
            {
                ArrivalTime = "13:50",
                DepartureTime = "15:00",
                FlightNumber = 33,
                FlightStatus = status,
                Gate = 3,
                Passengers = plane.Passengers,
                Plane = plane,
                Price = 1200,
                Route = plane.Way,
                Terminal = 4
            };
            context.Infos.Add(info);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
