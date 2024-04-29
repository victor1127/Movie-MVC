using MovieMVC.Models.TMDB;
using MovieMVC.Models.DataBase;
using MovieMVC.Enums;


namespace MovieMVC.Services.Interfaces
{
    public interface IDataMappingService
    {
        Task<Movie> MapMovieDetailAsync(MovieDetail movieDetail);
        ActorDetail MapActorDetail(ActorDetail actor);
    }
}
