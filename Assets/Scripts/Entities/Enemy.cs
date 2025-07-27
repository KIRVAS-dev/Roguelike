namespace Entities
{
    public class Enemy : IEnemy
    {
        [Inject] private IWeapon _weapon;
    }
}