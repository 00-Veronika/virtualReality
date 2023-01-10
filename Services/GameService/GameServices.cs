using EntityFrameworkSample;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.ViewModels.GamesVM;
using virtualReality.ViewModels.GenreVM;

namespace virtualReality.Services.GameService
{
    public class GameServices : IGameServices
    {
        HttpWebRequest request;
        HttpWebResponse response = null;

        private readonly MyDbContext _context;
        private readonly SignInManager<Users> _signInManager;
        public GameServices(MyDbContext context, SignInManager<Users> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Delete(int Id)
        {
            //GETS ALL THE PROPERTIES TO DELETE
            var gameToDelete = _context.Games.FirstOrDefault(x => x.Id == Id);
            var imageToDelete = _context.Pictures.FirstOrDefault(x => x.games_Id == Id);

            //IF SUCH Games EXISTS DELETE 
            if (gameToDelete != null)
            {
                _context.Pictures.Remove(imageToDelete);
                _context.Games.Remove(gameToDelete);
                StreamToReadAndDeleteFile(Id);
                _context.SaveChanges();
            }
        }


        public void Edit(EditGamesVM gamemodel)
        {
            //GETS SELECTED TAG
            var getGenre = _context.Genre.FirstOrDefault(x => x.name == gamemodel.Name);

            //CHECKS IF SUCH Games EXISTS
            if (gamemodel.Id == 0)
            {
                //DOWNLOAD TO SPECIFIED FILE PATH
                var path = Stream(gamemodel.url);
                //PREPARE OBJECTS TO CREATE
                var gameToTypes = new GameToType();
                var gameToCreate = new Games()
                {

                    Id = gamemodel.Id,
                    Name = gamemodel.Name,
                    manufacturer = gamemodel.manufacturer,
                    releaseDate = gamemodel.releaseDate,
                    Price = gamemodel.Price,
                    url = new Pictures
                    {
                        url = path,
                        games_Id = gamemodel.Id
                    }
                };

                //ADD Games TO DB AND THEN GET ITS ID
                _context.Games.Add(gameToCreate);
                _context.SaveChanges();
                var getCreatedGames = _context.Games.FirstOrDefault(x => x.Genre == gamemodel.Genre);

                //USES THE ID WE GET FROM ABOVE CODE AND SETS VALUES
                gameToTypes.genre_Id = getGenre.Id;
                gameToTypes.games_Id = gamemodel.Id;
                _context.GameToTypes.Add(gameToTypes);
            }
            else
            {
                //GET THE Games AND ALL OF IT PROPERTIES TO EDIT
                var GamesToEdit = _context.Games.FirstOrDefault(s => s.Id == gamemodel.Id);
                var GamesImageToEdit = _context.Pictures.FirstOrDefault(x => x.games_Id == gamemodel.Id);
                var GamesTagToEdit = _context.GameToTypes.FirstOrDefault(x => x.games_Id == gamemodel.Id);
                var TagToEdit = _context.Genre.FirstOrDefault(x => x.Id == getGenre.Id);


                //CHECKS IF THERE's a Games TO EDIT
                if (GamesToEdit != null)
                {
                    var newpath = "";
                    if (gamemodel.url != "")
                    {
                        //DELETES THE IMG SET TO THE CURR Games AND REPLACE WITH NEW
                        StreamToReadAndDeleteFile(gamemodel.Id);
                        newpath = Stream(gamemodel.url, gamemodel.Id);
                    }

                    //UPDATE IF NEW PATH GIVEN
                    if (newpath != null)
                    {
                        GamesImageToEdit.url = newpath;
                        _context.Pictures.Update(GamesImageToEdit);
                    }

                    //UPDATE
                    _context.Games.Update(GamesToEdit);


                    //UPDATE MANY TO MANY TABLE
                    if (GamesTagToEdit != null)
                    {
                        _context.GameToTypes.Remove(GamesTagToEdit);
                        _context.SaveChanges();
                        var GamesToTagUpdate = new GameToType();
                        GamesToTagUpdate.genre_Id = TagToEdit.Id;
                        GamesToTagUpdate.games_Id = GamesToEdit.Id;
                        _context.GameToTypes.Add(GamesToTagUpdate);
                    }
                }
            }
            _context.SaveChanges();
        }

        //ADD TO ORDER
        public void AddToOrder(int Id)
        {
            var getGames = GetGamesById(Id);
            var userId = (_signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (getGames != null && userId != null)
            {
                var orderToAdd = new Orders()
                {
                    Game_Id = getGames.Id,
                    //user_Id = userId,
                    Status = "Proccesing"
                };

                _context.Orders.Add(orderToAdd);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("How did we get here");
            }

        }

        //MAPPING
        private static Expression<Func<Games, GamesVM>> MapToGamesVM()
        {
            return x => new GamesVM()
            {
                Id = x.Id,

                Name = x.Name,
                Genre = x.Genre,
                Price = x.Price,
                Manufacturer = x.manufacturer,
                ReleaseDate = x.releaseDate

            };
        }

        //MAPPING
        private static Expression<Func<Genre, GenreVM>> MapToTagVM()
        {
            return x => new GenreVM()
            {
                Id = x.Id,
                Name = x.name
            };
        }

        //RETURNS ALL GamesS
        public List<GamesVM> GetAllGamess()
        {
            var Games = _context.Games.Select(MapToGamesVM()).ToList();

            return Games;
        }

        //GETS Games BY ID
        public Games GetGamesById(int Id)
        {
            var Games = _context.Games.FirstOrDefault(x => x.Id == Id);
            return Games;
        }

        public GamesVM GetGamesByIdAndUserIdVM(int Id, int userId)
        {
            var Games = _context.Games.FirstOrDefault(x => x.Id == Id);
            Games.url = _context.Pictures.FirstOrDefault(x => x.Id == Games.Id);
            var GetStatus = _context.Orders.FirstOrDefault(x => x.user_Id == userId);
            Games.order = GetStatus;
            var getGenre = _context.GameToTypes.FirstOrDefault(x => x.games_Id == Games.Id);
            var Genre = _context.Genre.FirstOrDefault(x => x.Id == getGenre.genre_Id);
            var userName = _context.Users.FirstOrDefault(x => x.Id == userId).username;

            var newGames = new GamesVM()
            {
                Id = Games.Id,

                Price = Games.Price,
                url = Games.url.url,
                order = Games.order,
                Genre = Games.Genre,
                userId = userId,
                Username = userName,
            };
            return newGames;
        }

        public IEnumerable<GenreVM> GetAllTags()
        {
            var tags = _context.Genre.Select(MapToTagVM()).ToList();
            return tags;
        }

        //METHODS THAT GET PROPERTIES VALUES BY GamesSVIEWMODEL
        public Pictures GetImageByGamesVM(GamesVM Games)
        {
            var image = _context.Pictures.FirstOrDefault(p => p.games_Id == Games.Id);
            return image;
        }

        public Genre GetTagByGamesVM(GamesVM Games)
        {
            var GameToTypes = _context.GameToTypes.FirstOrDefault(x => x.games_Id == Games.Id);
            if (GameToTypes != null)
            {
                var GameToType = _context.Genre.FirstOrDefault(x => x.Id == GameToTypes.genre_Id);
                return GameToType;
            }
            return new Genre();
        }

        //METHODS THAT GET PROPERTIES VALUES BY GamesS
        public Genre GetTagByGames(Games Games)
        {
            var GamesToTag = _context.GameToTypes.FirstOrDefault(x => x.games_Id == Games.Id);
            if (GamesToTag != null)
            {
                var genre = _context.Genre.FirstOrDefault(x => x.Id == GamesToTag.genre_Id);
                return genre;
            }
            return null;
        }
        //RETURNS THE IMAGE OF THE GIVEN Games 
        public Pictures GetImageByGames(Games Games)
        {
            var image = _context.Pictures.FirstOrDefault(p => p.games_Id == Games.Id);
            return image;
        }

        //GETS THE IMG TABLE COUNT
        private int GetImagesCount()
        {
            var count = _context.Pictures.Count();
            return count;
        }

        //DOWNLOADS FILE IN SPECIFIED PATH FROM INTERNET WITH GIVEN URL
        public string Stream(string link)
        {
            try
            {
                request = (HttpWebRequest)WebRequest.Create(link);
                request.Timeout = 1000;
                request.AllowWriteStreamBuffering = false;
                response = (HttpWebResponse)request.GetResponse();

                Stream s = response.GetResponseStream();

                //Write to disk
                string fileName = $"{(GetImagesCount() + 1)}.png";
                FileStream fs = new FileStream($"./wwwroot/Images/{fileName}", FileMode.Create, FileAccess.ReadWrite);

                byte[] read = new byte[256];

                int count = s.Read(read, 0, read.Length);

                while (count > 0)

                {
                    fs.Write(read, 0, count);

                    count = s.Read(read, 0, read.Length);

                }
                //Close everything

                fs.Close();

                s.Close();

                response.Close();

                return fileName;
            }

            catch (System.Net.WebException)

            {
                if (response != null)

                    response.Close();
                return null;
            }
        }

        public string Stream(string link, int Id)
        {
            if (link == null)
            {
                return null;
            }
            else
            {
                try
                {
                    request = (HttpWebRequest)WebRequest.Create(link);
                    request.Timeout = 1000;
                    request.AllowWriteStreamBuffering = false;
                    response = (HttpWebResponse)request.GetResponse();

                    Stream s = response.GetResponseStream();

                    //Write to disk
                    string fileName = $"{Id}.png";
                    FileStream fs = new FileStream($"./wwwroot/Images/{fileName}", FileMode.Create, FileAccess.ReadWrite);

                    byte[] read = new byte[256];

                    int count = s.Read(read, 0, read.Length);

                    while (count > 0)

                    {
                        fs.Write(read, 0, count);
                        count = s.Read(read, 0, read.Length);
                    }
                    //Close everything
                    fs.Close();
                    s.Close();
                    response.Close();
                    return fileName;
                }
                catch (System.Net.WebException)
                {
                    if (response != null)
                        response.Close();
                    return null;
                }
            }
        }
        public void StreamToReadAndDeleteFile(int Id)
        {
            string fileName = $"./wwwroot/Images/{Id}.png";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
        public void Dispose()
        {

        }

        public Genre GetTagByGameVM(GamesVM Games)
        {
            throw new NotImplementedException();
        }

        public Genre GetTagByGame(Games game)
        {
            throw new NotImplementedException();
        }

        public Pictures GetImageByGame(Games game)
        {
            throw new NotImplementedException();
        }

        public Pictures GetImageByGamesVM(Games game)
        {
            throw new NotImplementedException();
        }

        IEnumerable<GenreVM> IGameServices.GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public Games GetGameById(int Id)
        {
            throw new NotImplementedException();
        }

        public GamesVM GetGameByIdAndUserIdVM(int Id, int userId)
        {
            throw new NotImplementedException();
        }

        public List<GamesVM> GetAllGame()
        {
            throw new NotImplementedException();
        }

        public Genre GetTypeByGameVM(GamesVM game)
        {
            throw new NotImplementedException();
        }

        public Genre GetTypeByGame(Games game)
        {
            throw new NotImplementedException();
        }

        public List<GamesVM> GetAllGames()
        {
            throw new NotImplementedException();
        }
    }
}
