using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamPowered.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        private ICollection<Review> reviews;
        private ICollection<Rating> ratings;
        private ICollection<Image> imageUrls;

        public Game()
        {
            this.reviews = new HashSet<Review>();
            this.ratings = new HashSet<Rating>();
            this.imageUrls = new HashSet<Image>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public string SystemRequirements { get; set; }

        public virtual ICollection<Image> ImagesUrls
        {
            get { return this.imageUrls; }
            set { this.imageUrls = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
