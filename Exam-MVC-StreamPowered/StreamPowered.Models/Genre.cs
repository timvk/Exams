using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        private ICollection<Game> games;

        public Genre()
        {
            this.games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Game> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
