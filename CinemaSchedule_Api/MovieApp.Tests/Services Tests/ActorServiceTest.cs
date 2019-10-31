using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApp.Data.EF;
using System.Threading.Tasks;
using MovieApp.BL.Services;
using MovieApp.BL.Infrastructure;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MovieApp.Tests.Services_Tests
{
    [TestClass]
    public class ActorServiceTest
    {
        DbContextOptionsBuilder<MovieAppContext> builder;
        MovieAppContext context;
        ActorService actorService;

        [TestInitialize]
        public void Initialize()
        {
            builder = new DbContextOptionsBuilder<MovieAppContext>();
            builder.UseInMemoryDatabase(databaseName: "testMovieAppDb");
            context = new MovieAppContext(builder.Options);
            //data seed
            DatabaseInitialization.InitDatabaseContext(context);
            actorService = new ActorService(context);
        }
        
        [TestMethod]
        public async Task GetById()
        {
            var actor = await actorService.GetByIdAsync(1);
            Console.WriteLine(actor.Name);
            Assert.AreEqual(actor.Name, "Jackie Chan");
        }

        [TestMethod]
        public async Task GetActorsByMovie()
        {
            var actors = await actorService.GetMovieActorsAsync(1);
            Console.WriteLine(actors.Count());
            Assert.AreEqual(actors.Count(), 2);
        }
    }
}