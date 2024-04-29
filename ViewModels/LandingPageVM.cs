using MovieMVC.Models.DataBase;
using MovieMVC.Models.TMDB;


namespace MovieMVC.ViewModels
{
    public class LandingPageVM
    {
        public List<Collection> CustomCollections { get; set; }
        public MovieSearch NowPlaying { get; set; }
        public MovieSearch Popular { get; set; }
        public MovieSearch Upcomming { get; set; }
    }
}
