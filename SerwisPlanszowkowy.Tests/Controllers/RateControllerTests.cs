using Application.Services;
using Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SerwisPlanszowkowy.Controllers;
using SerwisPlanszowkowy.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SerwisPlanszowkowy.Tests.Controllers
{
    [TestClass]
    public class RateControllerTests
    {

        private Mock<IRateService> rateService;
        private Mock<IGameService> gameService;
        private RateController ratesController;
        private List<Rate> ratesList;

        [TestInitialize]
        public void Initialize()
        {
            rateService = new Mock<IRateService>();
            gameService = new Mock<IGameService>();

            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns("userName");
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            

            ratesController = new RateController(rateService.Object, gameService.Object);
            ratesController.ControllerContext = mock.Object;
            ratesList = new List<Rate>()
            {
                new Rate{Id=1, GameId = 1,  UserId = 1, Value=6, PublishedDate = DateTime.Parse("2015-01-21")},
                new Rate{Id=2, GameId = 1,  UserId = 2, Value=5, PublishedDate = DateTime.Parse("2015-01-21")},
                new Rate{Id=3, GameId = 1,  UserId = 3, Value=3, PublishedDate = DateTime.Parse("2015-01-21")}
            };

            AutoMapperConfig.Configure();

        }

        [TestMethod]
        public void CreateRate()
        {

            //arrange
            var rate = new Rate { Id = 25, Value = 10, GameId = 2, UserId = 1 };


            //act
            rateService.SetupAllProperties();
            var result = ratesController.Create(rate) as RedirectToRouteResult;


            //assert
            Assert.AreEqual("Details", result.RouteValues["action"]);
            Assert.AreEqual("Game", result.RouteValues["controller"]);
        }
        [TestMethod]
        public void InvalidCreateRate()
        {

            //arrange
            var rate = new Rate { Id = 25, Value = 10, GameId = 2, UserId = 1 };

            ratesController.ModelState.AddModelError("Error", "Something went wrong");

            //Act

            var result = (ViewResult)ratesController.Create(rate);


            //Assert

            Assert.AreEqual("", result.ViewName);
        }


        [TestMethod]
        public void TestDetailsViewData()
        {
            //arrange

            rateService.Setup(x => x.GetRateById(1)).Returns(ratesList.Find(c => c.Id == 1));


            //act
            var result = (ViewResult)ratesController.Details(1);
            var rate = (Rate)result.ViewData.Model;

            //assert
            Assert.AreEqual(6, rate.Value);
            Assert.AreEqual(DateTime.Parse("2015-01-21"), rate.PublishedDate);
        }

        [TestMethod]
        public void TestDetailsReturnHttpNotFoundResult()
        {
            rateService.Setup(x => x.GetRateById(5)).Returns(ratesList.Find(c => c.Id == 5));

            //Act
            var result = ratesController.Details(5);

            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void TestDetailsReturnBadRequest()
        {
           
            //Act
            var result = ratesController.Details(null);

            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));
        
        }



        [TestMethod]
        public void TestDeleteConfirmed()
        {

            //act
            rateService.SetupAllProperties();
            var result = ratesController.DeleteConfirmed(1) as RedirectToRouteResult;


            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
