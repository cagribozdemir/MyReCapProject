using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join a in context.Colors on c.ColorId equals a.ColorId
                             join r in context.Rentals on c.CarId equals r.CarId
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 BrandName = b.BrandName,
                                 ColorName = a.ColorName,
                                 ModelName = c.ModelName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
