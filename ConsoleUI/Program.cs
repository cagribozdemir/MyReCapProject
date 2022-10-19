using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

CarManager carManager = new CarManager(new EfCarDal());

foreach (var car in carManager.GetCarsByBrandId(1))
{
    Console.WriteLine(car.ModelYear + " model " + car.Description + " " + car.DailyPrice + " TL");
}