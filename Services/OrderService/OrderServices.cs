using EntityFrameworkSample;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
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

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.user_Id == id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public IEnumerable<Orders> GetAll()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }

        public IEnumerable<Games> GetAllOrderedGames()
        {
            var orders = GetAll();
            List<Games> orderedGames = new List<Games>();
            using (var _gamesService = new GameService.GameServices(_context, _signInManager))
            {
                foreach (var game in orders)
                {
                    orderedGames.Add(_gamesService.GetGamesById(game.Game_Id));
                }
            }
            return orderedGames;
        }


        public IEnumerable<OrderVM> GetAllOrderForLoggedUser()
        {
            var userId = GetUserId();
            var userOrders = _context.Orders.Select(MapToOrderVM()).Where(x => x.user_Id == userId).ToList();

            return userOrders;
        }

        public IEnumerable<GamesVM> GetUserOrderedGames()
        {
            var userOrders = GetAllOrderForLoggedUser();
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

        public IEnumerable<GamesVM> GetAllOrderedGamesVM()
        {
            var orders = GetAll();
            List<GamesVM> orderedGames = new List<GamesVM>();

            using (var _gameService = new GameService.GameServices(_context, _signInManager))
            {
                foreach (var order in orders)
                {
                    orderedGames.Add(_gameService.GetGameByIdAndUserIdVM(order.Game_Id, order.Id));
                }
            }

            return orderedGames;
        }

        public Orders GetOrderByGames(Games game)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Game_Id == game.Id);
            return order;
        }

        public Orders GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);
            return order;
        }
        public Orders GetOrderByGamesVM(GamesVM game)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Game_Id == game.Id);
            return order;
        }

        public Orders GetOrderByUserId(int userId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.user_Id == userId);
            return order;
        }

        public void Edit(int id, string status)
        {
            var gameStatusToEdit = _context.Orders.FirstOrDefault(x => x.user_Id == id);
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
                Price = x.Price
                
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

        private int GetUserId()
        {
            var id = _signInManager.Context.User.FindFirstValue("Id");
            var result = int.TryParse(id, out int intId) ? intId : -1;
            return result;
        }

        public Orders GetOrderByGame(Games game)
        {
            throw new NotImplementedException();
        }

    }
}
