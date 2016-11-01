using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    using Models.Home;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var homePage = new HomeViewModel()
            {
                Games = this.Data.Games
                    .OrderByDescending(g => g.Ratings.Average(r => r.RatingValue))
                    .ThenBy(g => g.Title)
                    .Take(5)
                    .Select(GamesViewModel.Create)
                    .ToList(),
                Reviews = this.Data.Reviews
                    .OrderByDescending(r => r.CreatedOn)
                    .Take(5)
                    .Select(ReviewsViewModel.Create)
                    .ToList()
            };

            return View(homePage);
        }

    }
}