using Entities;

namespace Factories
{
    public class ConcreteFactory : AbstractFactory
    {
        public IEnemy Create()
        {
            IEnemy enemy = new Enemy();
            Inject(enemy);
            return enemy;
        }
    }
}