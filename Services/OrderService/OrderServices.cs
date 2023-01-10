using EntityFrameworkSample;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using virtualReality.Entities;
using virtualReality.ViewModels;
using virtualReality.ViewModels.GamesVM;

namespace virtualReality.Services.OrderService
{
    public class OrderServices : IOrderServices
    {
        private readonly MyDbContext _context;
        private readonly SignInManager<Users> _signInManager;
        public OrderServices(MyDbContext context, SignInManager<Users> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public void Delete(int Id)
        {
            var Order = _context.Orders.FirstOrDefault(x => x.user_Id == Id);
            _context.Orders.Remove(Order);
            _context.SaveChanges();
        }

        public IEnumerable<Orders> GetAll()
        {
            var Orders = _context.Orders.ToList();

            return Orders;
        }

        public IEnumerable<Games> get_All_Ordered_Games()
        {
            var Orders = GetAll();
            List<Games> orderedGames = new List<Games>();
            using (var _gamesService = new GameService.GameServices(_context, _signInManager))
            {
                foreach (var game in Orders)
                {
                    orderedGames.Add(_gamesService.GetGamesById(game.Game_Id));
                }
            }
            return orderedGames;
        }


        public IEnumerable<OrderVM> getAllOrderForLoggedUser()
        {
            var userId = getUserId();
            var userOrders = _context.Orders.Select(MapToOrderVM()).Where(x => x.user_Id == userId).ToList();

            return userOrders;
        }

        public IEnumerable<GamesVM> getUserOrderedShoes()
        {
            var userOrders = getAllOrderForLoggedUser();
            List<GamesVM> orderedGames = new List<GamesVM>();
            using (var _gameService = new GameService.GameServices(_context, _signInManager))
            {
                foreach (var game in userOrders)
                {
                    orderedGames.Add(_gameService.GetGameByIdAndUserIdVM(game.games_Id, game.user_Id));
                }
            }
            return orderedGames;
        }

        public IEnumerable<GamesVM> Get_All_Ordered_GamesVM()
        {
            var Orders = GetAll();
            List<GamesVM> orderedShoes = new List<GamesVM>();
            using (var _gameService = new GameService.GameServices(_context, _signInManager))
            {
                foreach (var order in Orders)
                {
                    orderedShoes.Add(_gameService.GetGameByIdAndUserIdVM(order.Game_Id, order.Id));
                }
            }
            return orderedShoes;
        }

        public Orders getOrderByShoe(Games game)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Game_Id == game.Id);
            return order;
        }

        public Orders getOrderById(int Id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == Id);
            return order;
        }
        public Orders getOrderByShoeVM(GamesVM game)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Game_Id == game.Id);
            return order;
        }

        public Orders getOrderByUserId(int userId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.user_Id == userId);
            return order;
        }

        public void Edit(int Id, string status)
        {
            var gameStatusToEdit = _context.Orders.FirstOrDefault(x => x.user_Id == Id);
            if (gameStatusToEdit != null)
            {
                gameStatusToEdit.Status = status;
                _context.Orders.Update(gameStatusToEdit);
                _context.SaveChanges();
            }
        }

        private static Expression<Func<Games, GamesVM>> MapToGamesVM()
        {
            return x => new GamesVM()
            {
                Id = x.Id,

                
            };
        }

        private static Expression<Func<Orders, OrderVM>> MapToOrderVM()
        {
            return x => new OrderVM()
            {
                Id = x.Id,
                user_Id= x.user_Id,
                games_Id= x.Game_Id
            };
        }

        private string getUserId()
        {
            return _signInManager.Context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public IEnumerable<GamesVM> get_All_Ordered_GamesVM()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GamesVM> getUserOrderedGames()
        {
            throw new NotImplementedException();
        }

        public Orders getOrderByGame(Games game)
        {
            throw new NotImplementedException();
        }

        public Orders getOrderByGamesVM(GamesVM game)
        {
            throw new NotImplementedException();
        }
    }
}
