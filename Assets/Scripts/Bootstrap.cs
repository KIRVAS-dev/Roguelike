using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("Core");
    }
}