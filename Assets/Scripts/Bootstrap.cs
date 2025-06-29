using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("Core");
        }
    }
}