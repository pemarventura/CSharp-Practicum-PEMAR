using Application.Entities;

namespace Application.Interfaces
{
    public interface IServer
    {
        string TakeOrder(string unparsedOrder);
    }
}
