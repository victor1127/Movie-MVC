using MovieMVC.Models.TMDB;
using MovieMVC.Enums;

namespace MovieMVC.Services.Interfaces
{
    public interface IRemoteMovieService
    {
        Task<MovieDetail> MovieDetailAsync(int id);
        Task<MovieSearch> SearchMoviesAsync(MovieCategory category, int count);
        Task<ActorDetail> ActorDetailAsync(int id);

    }
}
