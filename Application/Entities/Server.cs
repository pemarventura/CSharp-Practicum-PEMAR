using Application.Interfaces;

namespace Application.Entities
{
    public class Server : IServer
    {
        private readonly IDishManager _dishManager;

        public Server(IDishManager dishManager)
        {
            _dishManager = dishManager;
        }

        public bool HasValidComposition()
        {
            return this != null && _dishManager != null;
        }

        public string TakeOrder(string unparsedOrder)
        {
            try
            {
                return _dishManager.GetDishes(unparsedOrder);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
