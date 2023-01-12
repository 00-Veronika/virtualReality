﻿using Microsoft.AspNetCore.Http;
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
        IEnumerable<Orders> GetAll();
        IEnumerable<Games> GetAllOrderedGames();
        IEnumerable<GamesVM> GetAllOrderedGamesVM();
        IEnumerable<OrderVM> GetAllOrderForLoggedUser(HttpContext httpContext);
        IEnumerable<GamesVM> GetUserOrderedGames(HttpContext httpContext);
        Orders GetOrderByGame(Games game);
        Orders GetOrderByGamesVM(GamesVM game);
        Orders GetOrderById(int id);
        Orders GetOrderByUserId(int userId);
    }
}
