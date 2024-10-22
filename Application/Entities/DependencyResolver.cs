
namespace Application.Entities
{
    public static class DependencyResolver
    {
        public static Server CreateServer()
        {
            // Create the dependencies
            var dishManager = new DishManager(new Dish());
            return new Server(dishManager);
        }
    }
}
