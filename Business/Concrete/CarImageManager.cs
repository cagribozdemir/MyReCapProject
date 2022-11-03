using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetByCarId(int carId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarId == carId));
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }
    }
}
