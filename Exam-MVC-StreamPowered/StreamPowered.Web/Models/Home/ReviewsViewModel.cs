namespace StreamPowered.Web.Models.Home
{
    using System;
    using System.Linq.Expressions;
    using StreamPowered.Models;

    public class ReviewsViewModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public int? GameId { get; set; }

        public string Game { get; set; }

        public static Expression<Func<Review, ReviewsViewModel>> Create
        {
            get
            {
                return r => new ReviewsViewModel()
                {
                    Id = r.Id,
                    Author = r.Author.UserName,
                    Content = r.Content,
                    CreatedOn = r.CreatedOn,
                    Game = r.Game.Title,
                    GameId = r.GameId
                };
            }
        } 
    }
}