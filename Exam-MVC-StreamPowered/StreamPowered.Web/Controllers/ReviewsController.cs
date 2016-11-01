using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    using System.Net;
    using Microsoft.AspNet.Identity;
    using Models.Review;
    using StreamPowered.Models;

    public class ReviewsController : BaseController
    {
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(ReviewBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid model");
            }
            var game = this.Data.Games.FirstOrDefault(s => s.Id == model.GameId);
            if (game == null)
            {
                return this.HttpNotFound();
            }

            var loggedUserId = this.User.Identity.GetUserId();
            var newReview= new Review()
            {
                AuthorId = loggedUserId,
                Content = model.Content,
                CreatedOn = DateTime.Now,
                GameId = model.GameId
            };

            game.Reviews.Add(newReview);
            this.Data.SaveChanges();

            return RedirectToAction("GameDetails", "Games", new {Id = model.GameId});
        }
    }
}