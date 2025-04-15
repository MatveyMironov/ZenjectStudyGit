using System;
using Zenject;

namespace ShooterSystem
{
    public class Shooter
    {
        private readonly IBulletProvider _bulletProvider;
        private readonly IPositionProvider _positionProvider;
        private readonly IRotationProvider _rotationProvider;
        private readonly IBulletParametersProvider _bulletParametersProvider;

        [Inject]
        public Shooter(IBulletProvider bulletProvider, IPositionProvider positionProvider, IRotationProvider rotationProvider, IBulletParametersProvider bulletParametersProvider)
        {
            _bulletProvider = bulletProvider ?? throw new ArgumentNullException(nameof(bulletProvider));
            _positionProvider = positionProvider ?? throw new ArgumentNullException(nameof(positionProvider));
            _rotationProvider = rotationProvider ?? throw new ArgumentNullException(nameof(rotationProvider));
            _bulletParametersProvider = bulletParametersProvider ?? throw new ArgumentNullException(nameof(bulletParametersProvider));
        }

        public void Shoot()
        {
            Bullet bullet = _bulletProvider.GetBullet();

            bullet.transform.SetPositionAndRotation(_positionProvider.GetPosition(), _rotationProvider.GetRotation());

            bullet.Setup(_bulletParametersProvider.GetBulletSpeed());

            bullet.gameObject.SetActive(true);
        }
    }
}