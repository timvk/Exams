namespace StreamPowered.Web.Models.Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Home;
    using StreamPowered.Models;

    public class GameDetailsViewModel : GamesViewModel
    {
        public string Description { get; set; }

        public string Author { get; set; }

        public int? GenreId { get; set; }

        public string Genre { get; set; }

        public string SystemRequirements { get; set; }

        public IEnumerable<ReviewsViewModel> Reviews { get; set; }

        public new static Expression<Func<Game, GameDetailsViewModel>> Create
        {
            get
            {
                return g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    AverageRating = g.Ratings.Average(r => r.RatingValue), //string.Format("{0:0.00}", answer)
                    ImageUrl = g.ImagesUrls.Select(i => i.Url),
                    Title = g.Title,
                    Author = g.Author.UserName,
                    Description = g.Description,
                    GenreId = g.GenreId,
                    Genre = g.Genre.Name,
                    Reviews = g.Reviews
                        .OrderByDescending(r => r.CreatedOn)
                        .Select(r => new ReviewsViewModel()
                        {
                            Id = r.Id,
                            Author = r.Author.UserName,
                            Content = r.Content,
                            CreatedOn = r.CreatedOn,
                            Game = r.Game.Title,
                            GameId = r.GameId
                        }),
                    SystemRequirements = g.SystemRequirements
                };
            }
        }
    }
}