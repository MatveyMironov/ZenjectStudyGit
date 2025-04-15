using Zenject;

namespace ShooterSystem
{
    public class BulletPoolProvider : IBulletProvider
    {
        private readonly BulletPool _bulletPool;

        [Inject]
        public BulletPoolProvider(BulletPool bulletPool)
        {
            _bulletPool = bulletPool != null ? bulletPool : throw new System.ArgumentNullException(nameof(bulletPool));
        }

        public Bullet GetBullet()
        {
            return _bulletPool.GetBullet();
        }
    }
}