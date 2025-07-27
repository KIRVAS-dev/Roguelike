using Dependencies;
using UnityEngine;

public class CoreContext : MonoBehaviour
{
    private void Awake()
    {
        var container = new DiContainer();

        container.InjectAll();
    }
    
    
}