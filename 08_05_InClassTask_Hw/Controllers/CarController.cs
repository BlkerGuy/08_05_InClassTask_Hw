using _08_05_InClassTask_Hw.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _08_05_InClassTask_Hw.Controllers
{
    public class CarController : Controller
    {
        private readonly List<Car> _cars;


        public CarController()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, Name="M5", BrandId=1 },
                new Car { Id = 2, Name="X6", BrandId=1 },
                new Car { Id = 3, Name="MercedesBenz",BrandId=2},
                new Car { Id = 4, Name="MercedesBenz S Class",BrandId=2}
            };
        }

        public IActionResult Index(int? id,string name )
        {
            if (id != null)
            {
                return View(_cars.FindAll(c => c.BrandId == id));
            }
            return View(_cars);
        }

        public IActionResult Detail(int? id)
        {
            List<CarDetail> carDetails = new List<CarDetail>
            {
                new CarDetail {Id=1,Name=_cars.Find(c=>c.Id==id).Name,Color="Black",Year="2023"},
                new CarDetail {Id=2,Name=_cars.Find(c=>c.Id==id).Name,Color="Blue",Year="2024"},
                new CarDetail {Id=3,Name=_cars.Find(c=>c.Id==id).Name,Color="Gray",Year="2024"},
                new CarDetail {Id=4,Name=_cars.Find(c=>c.Id==id).Name,Color="Gray",Year="2024"},
            };
            if (id != null)
            {
                return View(carDetails.FindAll(cd => cd.Id == id));
            }
            /*_cars.Find(c => c.Id == id);*/
            return View(carDetails);
        }
    }
}
