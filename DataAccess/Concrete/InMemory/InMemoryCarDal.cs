using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ColorId=1,BrandId=1,DailyPrice=300,Description="520d",CarId=1,ModelYear=2018},
                new Car{ColorId=2,BrandId=2,DailyPrice=100,Description="Megane",CarId=2,ModelYear=2019},
                new Car{ColorId=3,BrandId=2,DailyPrice=140,Description="Fluence",CarId=3,ModelYear=2017},
                new Car{ColorId=4,BrandId=5,DailyPrice=1000,Description="S500",CarId=4,ModelYear=2021},
                new Car{ColorId=1,BrandId=3,DailyPrice=170,Description="Focus",CarId=5,ModelYear=2019},
                new Car{ColorId=2,BrandId=4,DailyPrice=200,Description="Passat",CarId=6,ModelYear=2020}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
           
            _cars.Remove(carToDelete);


        }
       
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {   //Gönderdiğim ürün id'sine sahip olan listedeki arabayı bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
  
}
