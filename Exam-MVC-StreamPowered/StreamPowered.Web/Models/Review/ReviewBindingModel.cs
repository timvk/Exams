namespace StreamPowered.Web.Models.Review
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewBindingModel
    {
        [Required(ErrorMessage = "Cannot leave empty review.")]
        public string Content { get; set; }

        public int GameId { get; set; }
    }
}