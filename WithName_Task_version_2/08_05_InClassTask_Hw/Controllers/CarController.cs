using _08_05_InClassTask_Hw.Models;
using _08_05_InClassTask_Hw.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _08_05_InClassTask_Hw.Controllers
{
    public class CarController : Controller
    {
        private readonly List<Car> _cars;
        private readonly List<Brand> _brands;


        public CarController()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, Name="M5", BrandId=1 },
                new Car { Id = 2, Name="X6", BrandId=1 },
                new Car { Id = 3, Name="MercedesBenz",BrandId=2},
                new Car { Id = 4, Name="MercedesBenz S Class",BrandId=2}
            };

            _brands = new List<Brand>
            {
                new Brand{Id=1,Name="Bmw"},
                new Brand{Id=2,Name="Mercedes"}
            };
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                brands = _brands,
                cars=_cars
            };
            return View(homeVM);
        }
        public IActionResult CarIndex(int? id )
        {
            HomeVM homeVM = new HomeVM
            {
                cars=_cars
            };
            if (id != null)
            {
                HomeVM homeVM_2 = new HomeVM
                {
                    brands = _brands,
                    cars = _cars.FindAll(c => c.BrandId == id)
                };
                return View(homeVM_2);
            }
            return View(homeVM);
        }

        public IActionResult Detail(int? id)
        {
            List<CarDetail> carDetails = new List<CarDetail>
            {
                new CarDetail {Id=1,Name=_cars.Find(c=>c.Id==id).Name,Color="Black",Year="2023"},
                new CarDetail {Id=2,Name=_cars.Find(c=>c.Id==id).Name,Color="Blue",Year="2024"},
                new CarDetail {Id=3,Name=_cars.Find(c=>c.Id==id).Name,Color="Gray",Year="2024"},
                new CarDetail {Id=4,Name=_cars.Find(c=>c.Id==id).Name,Color="Brown",Year="2020"},
            };
            HomeVM homeVM = new HomeVM
            {
                CarDetails = carDetails
            };
            if (id != null)
            {
                HomeVM homeVM_2 = new HomeVM
                {
                    brands = _brands,
                    cars = _cars,
                    CarDetails = carDetails.FindAll(cd => cd.Id == id)
                };
                return View(homeVM_2);
            }
            return View(homeVM);
        }
    }
}
