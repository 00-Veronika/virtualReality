using System;
using System.Collections.Generic;
using virtualReality.Entities;
using virtualReality.ViewModels.GamesVM;
using virtualReality.ViewModels.GenreVM;

namespace virtualReality.Services.GameService
{
    public interface IGameServices : IDisposable

    // IDisposable се използва за освобождаване на място в паметта от обекти, които са инстанцирани без да се използват

    {
        string Stream(string link);
        void StreamToReadAndDeleteFile(int Id);
        void Edit(EditGamesVM gamemodel);
        void Delete(int Id);
        void AddToOrder(int Id);
        Genre GetTypeByGameVM(GamesVM shoe);
        Genre GetTypeByGame(Games game);
        Pictures GetImageByGame(Games game);
        Pictures GetImageByGamesVM(Games game);
        List<GamesVM> GetAllGames();
        IEnumerable<GenreVM> GetAllTypes();
        Games GetGameById(int Id);
        GamesVM GetGameByIdAndUserIdVM(int Id, int userId);
    }
}
