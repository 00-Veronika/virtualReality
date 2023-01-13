using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using virtualReality.Entities;
using virtualReality.ViewModels;
using virtualReality.ViewModels.GamesVM;

namespace virtualReality.Services.OrderService
{
    public interface IOrderServices 
    {
        void Delete(int id);
        void Edit(int id, string status);
        IEnumerable<Order> GetAll();
        IEnumerable<Game> GetAllOrderedGames();
        IEnumerable<GamesVM> GetAllOrderedGamesVM();
        IEnumerable<OrderVM> GetAllOrderForLoggedUser(HttpContext httpContext);
        IEnumerable<GamesVM> GetUserOrderedGames(HttpContext httpContext);
        Order GetOrderByGame(Game game);
        Order GetOrderByGamesVM(GamesVM game);
        Order GetOrderById(int id);
        Order GetOrderByUserId(int userId);
    }
}
