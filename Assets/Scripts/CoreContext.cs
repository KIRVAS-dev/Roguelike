using UnityEngine;

namespace Assets.Scripts
{
    public class CoreContext : MonoBehaviour
    {
        [SerializeField] private Test2 _test2;
        
        
        private void Awake()
        {
            var container = new DiContainer();
            
            container.Bind<Test1>();
            container.Bind(_test2);

            container.InjectAll();
        }
    }
}