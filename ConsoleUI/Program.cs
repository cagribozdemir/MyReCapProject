using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

CarManager carManager = new CarManager(new EfCarDal());
//AddTest(carManager);

var carId1 = carManager.GetById(1).Data;
Console.WriteLine(carId1.ModelYear + "/" +carId1.Description);

var result = carManager.GetCarDetailDtos();
foreach (var car in result.Data)
{
    Console.WriteLine(car.ModelYear + " model " + car.ColorName + car.BrandName + " " + car.DailyPrice + " TL");
}

static void AddTest(CarManager carManager)
{
    Car car6 = new Car { CarId = 6, BrandId = 3, ColorId = 4, ModelYear = 2020, Description = "Gasoline", DailyPrice = 1000 };

    carManager.Add(car6);
}