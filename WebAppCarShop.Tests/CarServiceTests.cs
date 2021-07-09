using System;
using Xunit;
using WebAppCarShop.Models.Service;
using WebAppCarShop.Models.Repo;
using WebAppCarShop.Models.Data;
using WebAppCarShop.Models.ViewModel;

namespace WebAppCarShop.Tests
{
    public class CarServiceTests
    {
        [Fact]
        public void FindAllCars()
        {
            //Arrange                               //Has a premade list of 3 cars
            ICarService carService = new CarService(new InMemoryCarRepo(), new InMemCarBrandRepo());
            int expectedSize = 3;

            //Act
            var result = carService.All().CarList;

            //Assert
            Assert.Equal(expectedSize, result.Count);
        }

        [Fact]
        public void AddCreateCar()
        {
            //Arrange                               //Has a premade list of 3 cars
            ICarService carService = new CarService(new InMemoryCarRepo(), new InMemCarBrandRepo());
            CreateCar createCar = new CreateCar() { Brand = "TestBrand", ModelName = "TestModel", Price = 99.99 };
            int beforeCreateCount = carService.All().CarList.Count;

            //Act
            var result = carService.Add(createCar);
            var carList = carService.All().CarList;           

            //Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Id);
            Assert.True((beforeCreateCount + 1) == carList.Count);
            Assert.Contains(result, carList);
            Assert.Equal("TestBrand", result.Brand);
            Assert.Equal("TestModel", result.ModelName);
            Assert.Equal(99.99, result.Price);
        }
    }
}
