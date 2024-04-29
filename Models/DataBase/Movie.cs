using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieMVC.Enums;

namespace MovieMVC.Models.DataBase
{
    public class Movie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string TagLine { get; set; }
        public string OverView { get; set; }
        public int RunTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public MovieRating Rating { get; set; }
        public float VoteAverage { get; set; }

        public byte[] Poster { get; set; }
        public string PosterType { get; set; }
        public byte[] BackDrop { get; set; }
        public string BackDropType { get; set; }
        public string TrailerUrl { get; set; }

        [NotMapped]
        [Display(Name ="Poster File")]
        public IFormFile PosterFile { get; set; }

        [NotMapped]
        [Display(Name = "Poster File")]
        public IFormFile BackDropFile { get; set; }

        public ICollection<MovieCollection> MovieCollections { get; set; } = new HashSet<MovieCollection>();
        public ICollection<Cast> Cast { get; set; } = new HashSet<Cast>();
        public ICollection<Crew> Crew { get; set; } = new HashSet<Crew>();

    }
}   
