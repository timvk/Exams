namespace StreamPowered.Web.Models.Home
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public IEnumerable<GamesViewModel> Games { get; set; }

        public IEnumerable<ReviewsViewModel> Reviews { get; set; }
    }
}