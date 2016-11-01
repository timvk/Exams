namespace StreamPowered.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Range(1, 5)]
        public int RatingValue { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }


    }
}
