using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;

namespace MovieApp.Tests
{
    public class DatabaseInitialization
    {
        public static void InitDatabaseContext(MovieAppContext context)
        {
            //Actors
            context.Actors.Add(new Actor { Id = 1, Name = "Jackie Chan" });
            context.Actors.Add(new Actor { Id = 2, Name = "Chris Tucker" });
            context.Actors.Add(new Actor { Id = 3, Name = "Keanu Reeves" });
            context.Actors.Add(new Actor { Id = 4, Name = "Carrie Anne-Moss" });

            //Genres
            context.Genres.Add(new Genre { Id = 1, Name = "Action" });
            context.Genres.Add(new Genre { Id = 2, Name = "Sci-Fi" });

            //Movies
            context.Movies.Add(new Movie { Id = 1, Name = "Rush Hour", GenreId = 1, Description = "Rush Hour description", ImageUri = "rush_hour.jpg" });
            context.Movies.Add(new Movie { Id = 2, Name = "The Matrix", GenreId = 2, Description = "The Matrix description", ImageUri = "the_matrix.jpg" });

            //Actors and Movies link entity
            context.ActorMovies.Add(new ActorMovies { Id = 1, ActorId = 1, MovieId = 1 });
            context.ActorMovies.Add(new ActorMovies { Id = 2, ActorId = 2, MovieId = 1 });
            context.ActorMovies.Add(new ActorMovies { Id = 3, ActorId = 3, MovieId = 2 });
            context.ActorMovies.Add(new ActorMovies { Id = 4, ActorId = 4, MovieId = 2 });

            //Showtimes
            context.ShowTimes.Add(new ShowTime { Id = 1, Date = "2019-10-25", Time = "10:00", MovieId = 1 });
            context.ShowTimes.Add(new ShowTime { Id = 2, Date = "2019-10-25", Time = "13:00", MovieId = 2 });
            context.ShowTimes.Add(new ShowTime { Id = 3, Date = "2019-10-25", Time = "15:00", MovieId = 1 });
            context.ShowTimes.Add(new ShowTime { Id = 4, Date = "2019-10-26", Time = "10:30", MovieId = 2 });
            context.ShowTimes.Add(new ShowTime { Id = 5, Date = "2019-10-26", Time = "15:00", MovieId = 2 });
            context.ShowTimes.Add(new ShowTime { Id = 6, Date = "2019-10-26", Time = "18:30", MovieId = 1 });

            context.SaveChangesAsync();
        }

    }
}
