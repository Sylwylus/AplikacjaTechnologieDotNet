using Application.Services;
using Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SerwisPlanszowkowy.Controllers;
using SerwisPlanszowkowy.Mappings;
using SerwisPlanszowkowy.ViewModels;
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
    public class GameControllerTests
    {

        private Mock<IGameService> gameService;
        private GameController gamesController;
        private List<Game> gamesList;

        [TestInitialize]
        public void Initialize()
        {
            gameService = new Mock<IGameService>();

            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns("userName");
            mock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);


            gamesController = new GameController(gameService.Object);
            gamesController.ControllerContext = mock.Object;
            gamesList = new List<Game>()
            {
                new Game{Id=1, Name = "Talisman", CategoryId = 1, Description = "Wyprawa do krainy smoków i magii! W tej pełnej przygód grze wyruszysz na niebezpieczną wyprawę po największy skarb, legendarną Koronę Władzy. Wcielisz się w wojownika, kapłana, czarnoksiężnika lub jednego z pozostałych jedenastu bohaterów władających magią lub mieczem.", Publisher = "Galakta", MaxNumberOfPlayers = 6, MinNumberOfPlayers = 2, PlayingTime = 150, PublishedDate = DateTime.Parse("2015-01-14"), SuggestedAge = 12, Accepted=true},
                new Game{Id =2, Name = "Wikingowie", CategoryId = 1, Description = "Gracze wcielają się w Jarlów wikingów, którzy walczą o władzę nad Północą i koronę Konunga. Władzę zdobędzie ten, który jako pierwszy złupi wszystkie wsie i przywiezie z nich córki thanów do swojego portu, jako symbol uznania jego praw do korony. ", Publisher = "Rebel", MaxNumberOfPlayers = 4, MinNumberOfPlayers = 3, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-15"), SuggestedAge = 12, Accepted=true},
                new Game{Id = 3,Name = "Wsiąść do Pociągu: Europa", CategoryId = 6, Description = " Ticket to Ride Europe to nowa wersja bestsellerowej gry Ticket to Ride, przeniesiona z obszaru Ameryki Północnej na Stary Kontynent. Zawiera nie tylko nową mapę, ale także nowe elementy gry, jak tunele, przeprawy promowe czy stacje kolejowe.", Publisher = "Rebel", MaxNumberOfPlayers = 5, MinNumberOfPlayers = 2, PlayingTime = 90, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8, Accepted=false},

            };

            AutoMapperConfig.Configure();

        }

        [TestMethod]
        public void CreateGame()
        {

            //arrange
            var game = new GameCreateEditViewModel { Id=25, Name = "Steampunk Rally", CategoryId = "8", Description = "Gracze wcielają się w znanych z historii naukowców I budują maszyny, którymi będą rywalizowali w wyścigu.", Publisher = "Roxley ", MaxNumberOfPlayers = 8, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8};


            //act
            gameService.SetupAllProperties();
            var result = gamesController.Create(game, null) as RedirectToRouteResult;


            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
         
        }
        [TestMethod]
        public void InvalidCreateGame()
        {

            //arrange
            var game = new GameCreateEditViewModel { Id = 25, Name = "Steampunk Rally", CategoryId = "8", Description = "Gracze wcielają się w znanych z historii naukowców I budują maszyny, którymi będą rywalizowali w wyścigu.", Publisher = "Roxley ", MaxNumberOfPlayers = 8, MinNumberOfPlayers = 2, PlayingTime = 60, PublishedDate = DateTime.Parse("2015-01-16"), SuggestedAge = 8 };


            gamesController.ModelState.AddModelError("Error", "Something went wrong");

            //Act

            var result = (ViewResult)gamesController.Create(game, null);


            //Assert

            Assert.AreEqual("", result.ViewName);
        }



        [TestMethod]
        public void TestDetailsViewData()
        {
            //arrange

            gameService.Setup(x => x.GetGameById(2)).Returns(gamesList.Find(c => c.Id == 2));


            //act
            var result = (ViewResult)gamesController.Details(2);
            var game = (GameDetailsViewModel)result.ViewData.Model;

            //assert
            Assert.AreEqual("Wikingowie", game.Name);
        
        }

        [TestMethod]
        public void TestDetailsReturnHttpNotFoundResult()
        {
            gameService.Setup(x => x.GetGameById(5)).Returns(gamesList.Find(c => c.Id == 5));

            //Act
            var result = gamesController.Details(5);

            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void TestDetailsReturnBadRequest()
        {

            //Act
            var result = gamesController.Details(null);

            //Assert
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));

        }



        [TestMethod]
        public void TestDeleteConfirmed()
        {

            //act
            gameService.SetupAllProperties();
            var result = gamesController.DeleteConfirmed(1) as RedirectToRouteResult;


            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }



        [TestMethod]
        public void IndexSort()
        {

            //arrange
            gameService.Setup(x => x.GetFilteredGames(null, null)).Returns(gamesList);

            //act
            var result = (ViewResult)gamesController.Index(null, "", 1, "name_desc", null, null);
            var games = (IEnumerable<GameViewModel>)result.ViewData.Model;

            //assert
            Assert.AreEqual(games.First().Name, "Wsiąść do Pociągu: Europa");
            Assert.AreEqual(games.Last().Name, "Talisman");
        }

     
    }
}
