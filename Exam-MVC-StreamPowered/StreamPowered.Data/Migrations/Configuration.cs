namespace StreamPowered.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StreamPoweredContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StreamPoweredContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Admin"));

                var userManager = new UserManager<User>(new UserStore<User>(context));
                var admin = new User
                {
                    UserName = resources.Username,
                    Email = resources.Email
                };

                userManager.Create(admin, resources.Password);
                userManager.AddToRole(admin.Id, "Admin");

                userManager = new UserManager<User>(new UserStore<User>(context));
                var someUser = new User
                {
                    UserName = "Student",
                    Email = "Student@softuni.bg"
                };

                userManager.Create(someUser, "studentPass123");

                userManager = new UserManager<User>(new UserStore<User>(context));
                var newUser = new User
                {
                    UserName = "fiLeV",
                    Email = "fiLeV@gmail.com"
                };

                userManager.Create(newUser, "FiLevs!Sup3rS3cr37!P@ssw0rd");
            }

            if (!context.Genres.Any())
            {
                context.Genres.Add(new Genre(){Name = "Action"});
                context.Genres.Add(new Genre() { Name = "RPG" });
                context.Genres.Add(new Genre() { Name = "Funny" });
                context.Genres.Add(new Genre() { Name = "Strategy" });
                context.Genres.Add(new Genre() { Name = "Adventure" });
                context.Genres.Add(new Genre() { Name = "Casual" });
                context.Genres.Add(new Genre() { Name = "Racing" });
                context.Genres.Add(new Genre() { Name = "Sports" });
                context.Genres.Add(new Genre() { Name = "Simulation" });

                context.SaveChanges();
            }

            if (!context.Images.Any())
            {
                context.Images.Add(new Image(){Url = "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_34090867f1a02b6c17652ba9043e3f622ed985a9.600x338.jpg?t=1447694262"});
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_4733a1f56becbff21118435bd49561d0ed2392e7.600x338.jpg?t=1447358782" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_09f21774b2309fcb67a2d9f8b385b47c48e985ff.600x338.jpg?t=1447883099" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_ea78dfa1d7d81c3781287cab165f64ca70f1f2ea.600x338.jpg?t=1447687485" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002574.600x338.jpg?t=1447886799" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_4162b10390d84aa600e5ed895fdc885482eb2e71.600x338.jpg?t=1421333577" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_e86e8ce863bd67f5fcc5f03b1f4cf75a76f711b6.600x338.jpg?t=1448057367" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_1d30c9a215fd621e2fd74f40d93b71587bf6409c.600x338.jpg?t=1447694262" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_baa02e979cd3852e3c4182afcd603ab64e3502f9.600x338.jpg?t=1447694262" });
                context.Images.Add(new Image() { Url = "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_f7861bd71e6c0c218d8ff69fb1c626aec0d187cf.600x338.jpg?t=1447358782" });

                context.SaveChanges();
            }

            if (!context.Games.Any())
            {
                var game1 = new Game()
                {
                      Title = "Counter-Strike: Global Offensive",
                      Description ="Counter-Strike: Global Offensive (CS: GO) will expand upon the team-based action gameplay that it pioneered when it was launched 14 years ago. CS: GO features new maps, characters, and weapons and delivers updated versions of the classic CS content (de_dust, etc.).",
                      SystemRequirements = @"Windows\r\nMINIMUM: \r\nOS: Windows® 7/Vista/XP \r\nProcessor: Intel® Core™ 2 Duo E6600 or AMD Phenom™ X3 8750 processor or better \r\nMemory: 2 GB RAM \r\nGraphics: Video card must be 256 MB or more and should be a DirectX 9-compatible with support for Pixel Shader 3.0 \r\nDirectX: Version 9.0c \r\nHard Drive: 8 GB available space",
                      Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                      Genre = context.Genres.FirstOrDefault(g =>g.Name=="Action")
                };
                game1.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_34090867f1a02b6c17652ba9043e3f622ed985a9.600x338.jpg?t=1447694262"));
                game1.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_1d30c9a215fd621e2fd74f40d93b71587bf6409c.600x338.jpg?t=1447694262"));
                game1.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/730/ss_baa02e979cd3852e3c4182afcd603ab64e3502f9.600x338.jpg?t=1447694262"));
                context.Games.Add(game1);

                var game2 = new Game()
                {
                    Title = "Fallout 4",
                    Description = "Bethesda Game Studios, the award-winning creators of Fallout 3 and The Elder Scrolls V: Skyrim, welcome you to the world of Fallout 4 – their most ambitious game ever, and the next generation of open-world gaming.",
                    SystemRequirements =@"MINIMUM: \r\nOS: Windows 7/8/10 (64-bit OS required) \r\nProcessor: Intel Core i5-2300 2.8 GHz/AMD Phenom II X4 945 3.0 GHz or equivalent \r\nMemory: 8 GB RAM \r\nGraphics: NVIDIA GTX 550 Ti 2GB/AMD Radeon HD 7870 2GB or equivalent \r\nHard Drive: 30 GB available space\r\nRECOMMENDED: \r\nOS: Windows 7/8/10 (64-bit OS required) \r\nProcessor: Intel Core i7 4790 3.6 GHz/AMD FX-9590 4.7 GHz or equivalent \r\nMemory: 8 GB RAM \r\nGraphics: NVIDIA GTX 780 3GB/AMD Radeon R9 290X 4GB or equivalent \r\nHard Drive: 30 GB available space",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Genre = context.Genres.FirstOrDefault(g => g.Name == "Action")
                };
                game2.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_4733a1f56becbff21118435bd49561d0ed2392e7.600x338.jpg?t=1447358782"));
                game2.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/377160/ss_f7861bd71e6c0c218d8ff69fb1c626aec0d187cf.600x338.jpg?t=1447358782"));
                context.Games.Add(game2);

                var game3 = new Game()
                {
                    Title = "Dota 2",
                    Description = "Dota is a competitive game of action and strategy, played both professionally and casually by millions of passionate fans worldwide. Players pick from a pool of over a hundred heroes, forming two teams of five players.",
                    SystemRequirements = @"Windows\r\nMINIMUM: \r\nOS: Windows 7 \r\nProcessor: Dual core from Intel or AMD at 2.8 GHz \r\nMemory: 4 GB RAM \r\nGraphics: nVidia GeForce 8600/9600GT, ATI/AMD Radeon HD2600/3600 \r\nDirectX: Version 9.0c \r\nNetwork: Broadband Internet connection \r\nHard Drive: 8 GB available space \r\nSound Card: DirectX Compatible",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Genre = context.Genres.FirstOrDefault(g => g.Name == "Strategy")
                };
                game3.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/570/ss_09f21774b2309fcb67a2d9f8b385b47c48e985ff.600x338.jpg?t=1447883099"));
                context.Games.Add(game3);

                var game4 = new Game()
                {
                    Title = "Grand Theft Auto V",
                    Description = "A young street hustler, a retired bank robber and a terrifying psychopath must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody, least of all each other.",
                    SystemRequirements = @"MINIMUM: \r\nOS: Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1, Windows Vista 64 Bit Service Pack 2* (*NVIDIA video card recommended if running Vista OS) \r\nProcessor: Intel Core 2 Quad CPU Q6600 @ 2.40GHz (4 CPUs) / AMD Phenom 9850 Quad-Core Processor (4 CPUs) @ 2.5GHz \r\nMemory: 4 GB RAM \r\nGraphics: NVIDIA 9800 GT 1GB / AMD HD 4870 1GB (DX 10, 10.1, 11) \r\nHard Drive: 65 GB available space \r\nSound Card: 100% DirectX 10 compatible\r\nRECOMMENDED: \r\nOS: Windows 8.1 64 Bit, Windows 8 64 Bit, Windows 7 64 Bit Service Pack 1 \r\nProcessor: Intel Core i5 3470 @ 3.2GHz (4 CPUs) / AMD X8 FX-8350 @ 4GHz (8 CPUs) \r\nMemory: 8 GB RAM \r\nGraphics: NVIDIA GTX 660 2GB / AMD HD 7870 2GB \r\nHard Drive: 65 GB available space \r\nSound Card: 100% DirectX 10 compatible",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Genre = context.Genres.FirstOrDefault(g => g.Name == "Adventure")
                };
                game4.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/271590/ss_ea78dfa1d7d81c3781287cab165f64ca70f1f2ea.600x338.jpg?t=1447687485"));
                context.Games.Add(game4);

                var game5 = new Game()
                {
                    Title = "Team Fortress 2",
                    Description = "Nine distinct classes provide a broad range of tactical abilities and personalities. Constantly updated with new game modes, maps, equipment and, most importantly, hats!",
                    SystemRequirements=@"Windows\r\nMINIMUM: \r\nOS: Windows® 7 (32/64-bit)/Vista/XP \r\nProcessor: 1.7 GHz Processor or better \r\nMemory: 512 MB RAM \r\nDirectX: Version 8.1 \r\nNetwork: Broadband Internet connection \r\nHard Drive: 15 GB available space \r\nAdditional Notes: Mouse, Keyboard\r\nRECOMMENDED: \r\nOS: Windows® 7 (32/64-bit) \r\nProcessor: Pentium 4 processor (3.0GHz, or better) \r\nMemory: 1 GB RAM \r\nDirectX: Version 9.0c \r\nNetwork: Broadband Internet connection \r\nHard Drive: 15 GB available space \r\nAdditional Notes: Mouse, Keyboard",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Genre = context.Genres.FirstOrDefault(g => g.Name == "Action")
                };
                game5.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/440/0000002574.600x338.jpg?t=1447886799"));
                context.Games.Add(game5);

                var game6 = new Game()
                {
                    Title = "Garry's Mod",
                    Description="Garry's Mod is a physics sandbox. There aren't any predefined aims or goals. We give you the tools and leave you to play.",
                    SystemRequirements = @"Windows\r\nMINIMUM:  \r\nOS: Windows® Vista/XP/2000 \r\nProcessor: 1.8 GHz Processor \r\nMemory: 2GB RAM \r\nGraphics: DirectX® 9 level Graphics Card (Requires support for SSE) \r\nHard Drive: 1GB \r\nOther Requirements: Internet Connection\r\nMac OS X\r\nMINIMUM: OS X version Snow Leopard 10.6.3, 2GB RAM, NVIDIA GeForce 8 or higher, ATI X1600 or higher, or Intel HD 3000 or higher Mouse, Keyboard, Internet Connection, Monitor",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Genre = context.Genres.FirstOrDefault(g => g.Name == "Funny")
                };
                game6.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/4000/ss_4162b10390d84aa600e5ed895fdc885482eb2e71.600x338.jpg?t=1421333577"));
                context.Games.Add(game6);

                var game7 = new Game()
                {
                    Title = "Verdun",
                    Description = "Verdun is the first multiplayer FPS set in a realistic First World War setting. The merciless trench warfare offers a unique battlefield experience, immersing you and your squad into intense battles of attack and defense.",
                    SystemRequirements =@"Windows\r\nMINIMUM: \r\nOS: Windows Vista/7/8 \r\nProcessor: Intel Core2 Duo 2.4Ghz or Higher / AMD 3Ghz or Higher \r\nMemory: 3 GB RAM \r\nGraphics: Geforce GTX 960M / Radeon HD 7750 or higher, 1GB video card memory \r\nDirectX: Version 9.0c \r\nNetwork: Broadband Internet connection \r\nHard Drive: 12 GB available space \r\nAdditional Notes: Multiplayer only, make sure you have a stable and fast internet connection.\r\nRECOMMENDED: \r\nMemory: 4 GB RAM \r\nGraphics: 2GB video card memory",
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Genre = context.Genres.FirstOrDefault(g => g.Name == "Strategy")
                };
                game7.ImagesUrls.Add(context.Images.FirstOrDefault(i => i.Url == "http://cdn.akamai.steamstatic.com/steam/apps/242860/ss_e86e8ce863bd67f5fcc5f03b1f4cf75a76f711b6.600x338.jpg?t=1448057367"));
                context.Games.Add(game7);

                context.SaveChanges();
            }

            if (!context.Ratings.Any())
            {
                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "Student"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Counter-Strike: Global Offensive")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    RatingValue = 4,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Counter-Strike: Global Offensive")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Fallout 4")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    RatingValue = 2,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Fallout 4")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Dota 2")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "Student"),
                    RatingValue = 4,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Dota 2")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    RatingValue = 4,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Grand Theft Auto V")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "Student"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Grand Theft Auto V")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Team Fortress 2")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    RatingValue = 3,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Team Fortress 2")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "Student"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Garry's Mod")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Garry's Mod")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Verdun")
                });

                context.Ratings.Add(new Rating()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    RatingValue = 5,
                    Game = context.Games.FirstOrDefault(g => g.Title == "Verdun")
                });

                context.SaveChanges();
            }

            if (!context.Reviews.Any())
            {
                context.Reviews.Add(new Review()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "Student"),
                    Game = context.Games.FirstOrDefault(g => g.Title == "Counter-Strike: Global Offensive"),
                    Content = "i recommend this game",
                    CreatedOn = DateTime.Parse("2015-01-21T00:00:00")
                });

                context.Reviews.Add(new Review()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    Game = context.Games.FirstOrDefault(g => g.Title == "Counter-Strike: Global Offensive"),
                    Content = "The good CS with a lot of new benefits and bonuses",
                    CreatedOn = DateTime.Parse("2014-03-12T00:00:00")
                });

                context.Reviews.Add(new Review()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "Student"),
                    Game = context.Games.FirstOrDefault(g => g.Title == "Counter-Strike: Global Offensive"),
                    Content = "It's like Dota 2 but with less wizards and more Russians.",
                    CreatedOn = DateTime.Parse("2014-10-10T00:00:00")
                });

                context.Reviews.Add(new Review()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Game = context.Games.FirstOrDefault(g => g.Title == "Fallout 4"),
                    Content = "I have lost 10lbs since starting Fallout 4 because I keep forgetting to eat. 10/10 - best fitness game on Steam.",
                    CreatedOn = DateTime.Parse("2015-09-14T00:00:00")
                });

                context.Reviews.Add(new Review()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "admin"),
                    Game = context.Games.FirstOrDefault(g => g.Title == "Fallout 4"),
                    Content=@"Don't worry, the people who enjoy the game are too busy playing the game to write the positive reviews.\r\n\r\nedit: how is this review helpful\r\n\r\nalso for those who are calling me \""bethedrone\"" or w/e I'm not defending the <3 aspects of it. Fallout 4 is a good game, but it certainly isn't the same as the previous games. It got a bit dumbed down in terms of the rpg mechanic, sure, but that doesnt mean the game is bad. I honestly had low hopes for the game and ended up pleasantly surprised.",
                    CreatedOn = DateTime.Parse("2015-09-14T00:00:00")
                });

                context.Reviews.Add(new Review()
                {
                    Author = context.Users.FirstOrDefault(u => u.UserName == "fiLeV"),
                    Game = context.Games.FirstOrDefault(g => g.Title == "Team Fortress 2"),
                    Content= "one of few games that has stood the test of time and been tended well by devlopers. maybe if everyone just abandonded this we'd get HL3 already though. I suppose Valves thinking on it is \"well we have one successfull game still, why bother making another. We use to make games, now we just make money\"",
                    CreatedOn = DateTime.Parse("2015-05-22T00:00:00")
                });

                context.SaveChanges();
            }
        }
    }
}
