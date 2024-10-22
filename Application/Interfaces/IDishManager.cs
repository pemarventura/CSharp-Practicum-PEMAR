
using Application.Entities;

namespace Application.Interfaces
{
    public interface IDishManager
    {
        public string GetDishes(string unparsedOrder);
    }
}
