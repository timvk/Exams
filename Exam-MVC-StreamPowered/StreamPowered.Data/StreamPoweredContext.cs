namespace StreamPowered.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class StreamPoweredContext : IdentityDbContext<User>
    {
        public StreamPoweredContext()
            : base("name=StreamPoweredContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StreamPoweredContext, Configuration>());
        }
        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Review> Reviews { get; set; }

        public static StreamPoweredContext Create()
        {
            return new StreamPoweredContext();
        }
    }
}