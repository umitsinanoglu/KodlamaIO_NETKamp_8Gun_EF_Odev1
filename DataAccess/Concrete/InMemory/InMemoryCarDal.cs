using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            //Oracle, MongoDB, Postgre,SQL Server, MySQL
            _cars = new List<Car> {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=2021, DailyPrice=770000, Description = "Some other properties for this automobile" },
                new Car{Id=2, BrandId=1, ColorId=2, ModelYear=2022, DailyPrice=870000, Description = "Some other properties for this automobile" },
                new Car{Id=3, BrandId=2, ColorId=3, ModelYear=2023, DailyPrice=970000, Description = "Some other properties for this automobile" },
                new Car{Id=4, BrandId=2, ColorId=4, ModelYear=2024, DailyPrice=1070000, Description = "Some other properties for this automobile" },
                new Car{Id=5, BrandId=3, ColorId=5, ModelYear=2024, DailyPrice=975000, Description = "Some other properties for this automobile" },
                new Car{Id=6, BrandId=3, ColorId=5, ModelYear=2024, DailyPrice=875000, Description = "Some other properties for this automobile" },
                new Car{Id=7, BrandId=4, ColorId=5, ModelYear=2024, DailyPrice=670000, Description = "Some other properties for this automobile" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByDailyPriceRange(int min, int max)
        {
            return _cars.Where(c => c.DailyPrice <= max && c.DailyPrice >= min).ToList();
        }

        public Car GetById(int id)
        {
            return _cars.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId= car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
