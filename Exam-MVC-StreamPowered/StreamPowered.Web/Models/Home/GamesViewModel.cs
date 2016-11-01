using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamPowered.Web.Models.Home
{
    using System.Linq.Expressions;
    using StreamPowered.Models;

    public class GamesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> ImageUrl { get; set; }

        public double AverageRating { get; set; }

        public static Expression<Func<Game, GamesViewModel>> Create
        {
            get
            {
                return g => new GamesViewModel()
                {
                    Id = g.Id,
                    AverageRating = g.Ratings.Average(r => r.RatingValue),//string.Format("{0:0.00}", answer)
                    ImageUrl = g.ImagesUrls.Take(1).Select(i => i.Url),
                    Title = g.Title
                };
            }
        } 
    }
}