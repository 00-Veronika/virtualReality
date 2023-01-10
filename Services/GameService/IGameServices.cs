using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.ViewModels.GamesVM;
using virtualReality.ViewModels.GenreVM;

namespace virtualReality.Services.GameService
{
    interface IGameServices : IDisposable

    // IDisposable се използва за освобождаване на място в паметта от обекти, които са инстанцирани без да се използват

    {
        public string Stream(string link);
        public void StreamToReadAndDeleteFile(int Id);
        public void Edit(EditGamesVM gamemodel);
        public void Delete(int Id);
        public void AddToOrder(int Id);
        public Genre GetTypeByGameVM(GamesVM shoe);
        public Genre GetTypeByGame(Games game);
        public Pictures GetImageByGame(Games game);
        public Pictures GetImageByGamesVM(Games game);
        public List<GamesVM> GetAllGames();
        public IEnumerable<GenreVM> GetAllTypes();
        public Games GetGameById(int Id);
        public GamesVM GetGameByIdAndUserIdVM(int Id, string userId);
    }
}
