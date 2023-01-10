using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.ViewModels;
using virtualReality.ViewModels.GamesVM;

namespace virtualReality.Services.OrderService
{
    interface IOrderServices 
    {
        public void Delete(int Id);
        public void Edit(int Id, string status);
        public IEnumerable<Orders> GetAll();
        public IEnumerable<Games> get_All_Ordered_Games();
        public IEnumerable<GamesVM> Get_All_Ordered_GamesVM();
        public IEnumerable<OrderVM> getAllOrderForLoggedUser();
        public IEnumerable<GamesVM> getUserOrderedGames();
        public Orders getOrderByGame(Games game);
        public Orders getOrderByGamesVM(GamesVM game);
        public Orders getOrderById(int Id);
        public Orders getOrderByUserId(int userId);
    }
}
