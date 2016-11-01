using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamPowered.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models.Game;
    using Models.Home;
    using StreamPowered.Models;

    public class GamesController : BaseController
    {
        public ActionResult AllGames(int page = 1, int count = 5)
        {
            var games = this.Data.Games
                .OrderBy(g => g.Title)
                .Skip((page - 1) * count)
                .Take(count)
                .Select(GamesViewModel.Create)
                .ToList();

            ViewBag.MaxPages = (this.Data.Games.Count() + count - 1) / count;
            ViewBag.CurrentPage = page;

            return View(games);
        }

        public ActionResult GameDetails(int id)
        {
            var game = this.Data.Games
                .Where(g => g.Id == id)
                .Select(GameDetailsViewModel.Create)
                .FirstOrDefault();

            return View(game);
        }

        public ActionResult GamesByGenre(int id)
        {
            var games = this.Data.Games
                .Where(g => g.Genre.Id == id)
                .OrderBy(g => g.Title)
                .Select(GamesViewModel.Create)
                .ToList();

            ViewBag.Genre = this.Data.Genres.FirstOrDefault(l => l.Id == id).Name;

            return View(games);
        }

        //ne rabotiiiii : (
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGame(CreateGameBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();

            var newGame = new Game()
            {
                AuthorId = loggedUserId,
                Description = model.Description,
                Title = model.Title
            };

            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            return this.RedirectToAction("GameDetails", "Games", new { id = newGame.Id });
        }
    }
}