using UnityEngine;

namespace ShooterSystem
{
    public class Shooter
    {
        private readonly IPointProvider _pointProvider;
        private readonly IDirectionProvider _directionProvider;
        private readonly IBulletProvider _bulletProvider;

        public void Shoot()
        {
            Bullet bullet = _bulletProvider.GetBullet();
            bullet.Setup();
        }
    }
}