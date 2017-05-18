using Application.Services;
using Data;
using Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SerwisPlanszowkowy.Controllers;
using SerwisPlanszowkowy.Mappings;
using SerwisPlanszowkowy.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SerwisPlanszowkowy.Tests.Services
{
    [TestClass]
    public class RateServiceTests
    {
/*
        private Mock<CrudContext> context;
        private RateService ratesService;
        private Mock<DbSet<Rate>> mockSetRates;
        private List<User> usersList;

        [TestInitialize]
        public void Initialize()
        {
            
            var ratesList = new List<Rate>()
            {
                new Rate{Id=1, GameId = 1,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-21")},
                new Rate{Id=2, GameId = 1,  UserId = 2, Value=5, PublishedDate = DateTime.Parse("2015-01-21")},
                new Rate{Id=3, GameId = 1,  UserId = 3, Value=3, PublishedDate = DateTime.Parse("2015-01-21")}
            }.AsQueryable();

             usersList = new List<User>
            {
                new User{ Id=1, FirstName = "Barbara",LastName = "Potoczek",Moderator = false,Administrator = false,UserName = "Palindrom",Email = "lok@pal.il",DateOfBirth = DateTime.Parse("1990-01-02"),RegisterDate = DateTime.Parse("2015-01-02")},
                new User{Id =2, FirstName = "Kajko",LastName = "Kokoszek",Moderator = true,Administrator =true,UserName = "Superbohater",Email = "kokoszek@gmail.com",DateOfBirth = DateTime.Parse("1995-01-10"),RegisterDate = DateTime.Parse("2015-01-13")},
                new User{Id =3,FirstName = "Baltazar",LastName = "Gabka",Moderator = true,Administrator = false,UserName = "Minion",Email = "balterek@gmail.com",DateOfBirth = DateTime.Parse("1980-09-16"),RegisterDate = DateTime.Parse("2014-03-02")},
          };

            mockSetRates = new Mock<DbSet<Rate>>();
            
            mockSetRates.As<IQueryable<Rate>>().Setup(m => m.Provider).Returns(ratesList.Provider);
            mockSetRates.As<IQueryable<Rate>>().Setup(m => m.Expression).Returns(ratesList.Expression);
            mockSetRates.As<IQueryable<Rate>>().Setup(m => m.ElementType).Returns(ratesList.ElementType);
            mockSetRates.As<IQueryable<Rate>>().Setup(m => m.GetEnumerator()).Returns(() => ratesList.GetEnumerator());

        
            context = new Mock<CrudContext>();
            context.Setup(c => c.Rates).Returns(mockSetRates.Object);
                      

            ratesService = new RateService(context.Object);
            context.SetupAllProperties();


        }


        [TestMethod]
        public void GetRates()
        {
            context.SetupAllProperties();

            //act   
            var result = (Rate)ratesService.GetRates();


            //assert         
            Assert.AreEqual(5, result.Value);

        }


        [TestMethod]
        public void GetrateById()
        {
            //act   
            ratesService.GetRateById(2);


            //assert         
            Assert.AreEqual(null, context.Object.Rates.Find(3));

        }

        [TestMethod]
        public void EditRate()
        {

            //arrange
            var rate = new Rate { Id = 1, GameId = 1, UserId = 1, Value = 9, PublishedDate = DateTime.Parse("2015-01-21") };

       

            //act         

            ratesService.EditRate(rate);


            //assert
           
         
            var editedrate = context.Object.Rates.Find(1);
            Assert.AreEqual(9, editedrate.Value);
           

        }
        [TestMethod]
        public void CreateRate()
        {

            //arrange
            var rate = new Rate { Id = 25, GameId = 1, Value = 6 };
            var userName = "Minion";

            context = new Mock<CrudContext>();
            context.Setup(x => x.Rates.Add(It.IsAny<Rate>())).Returns((Rate u) => u);
            context.Setup(x => x.Users..Single(u => u.UserName == userName)).Returns(usersList.Single(u => u.UserName == userName));
            ratesService = new RateService(context.Object);

            //act         

            ratesService.CreateRate(rate, userName);


            //assert
            var addedrate = context.Object.Rates.Find(25);
            mockSetRates.Verify(m => m.Add(It.IsAny<Rate>()), Times.Once());
            Assert.AreEqual(3, addedrate.UserId);
            Assert.AreEqual(DateTime.Today, addedrate.PublishedDate);
        }



        [TestMethod]
        public void RemoveRate()
        {
          

            //act   
            ratesService.RemoveRate(3);


            //assert         
            Assert.AreEqual( null, context.Object.Rates.Find(3));
          
        }

        */

    }
}
