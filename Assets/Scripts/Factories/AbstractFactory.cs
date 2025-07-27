using Dependencies;

namespace Factories
{
    public abstract class AbstractFactory
    {
        [Inject] private DiContainer _container;

        protected void Inject(object obj)
        {
            _container.Bind(obj);
            _container.Inject(obj);
        }
    }
}