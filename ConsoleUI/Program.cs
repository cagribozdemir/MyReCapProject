using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//AddTest(carManager);
//CarManagerTest();
RentalTest();

static void AddTest(CarManager carManager)
{
    Car car6 = new Car { CarId = 6, BrandId = 3, ColorId = 4, ModelYear = 2020, Description = "Gasoline", DailyPrice = 1000 };

    carManager.Add(car6);
}

static void CarManagerTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var carId1 = carManager.GetById(1).Data;
    Console.WriteLine(carId1.ModelYear + "/" + carId1.Description);

    var result = carManager.GetCarDetailDtos();
    foreach (var car in result.Data)
    {
        Console.WriteLine(car.ModelYear + " model " + car.ColorName + car.BrandName + " " + car.DailyPrice + " TL");
    }
}

static void RentalTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    User user = new User { Id = 1, FirstName = "Çağrı", LastName = "Bozdemir", Email = "cagribozdemir0@gmail.com", Password = "123456" };
    userManager.Add(user);

    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    Customer customer = new Customer { Id = 1, UserId = 1, CompanyName = "cgrbozdemir" };
    customerManager.Add(customer);

    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    Rental rental1 = new Rental { Id = 1, CustomerId = 1, RentDate = new DateTime(2022, 10, 25), ReturnDate = new DateTime(2022, 11, 10) };
    rentalManager.Add(rental1);
    Rental rental2 = new Rental { Id = 2, CustomerId = 1, RentDate = new DateTime(2022, 10, 30), ReturnDate = new DateTime(2022, 12, 30) };
    rentalManager.Add(rental2);

    var result = rentalManager.GetAll();
    foreach (var rental in result.Data)
    {
        Console.WriteLine(rental.Id + ":" + rental.RentDate);
    }
}