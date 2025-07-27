using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Start()
    {
        Object.Instantiate(_player, transform.position, Quaternion.identity);
    }
}