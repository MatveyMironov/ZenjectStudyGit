using System.Collections.Generic;
using UnityEngine;

namespace ShooterSystem
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int initialPoolSize;
        [SerializeField] private int poolSizeIncreaseAmount;

        private readonly List<Bullet> _bullets = new();

        private void Start()
        {
            IncreasePoolSize(initialPoolSize);
        }

        public Bullet GetBullet()
        {
            if (_bullets.Count == 0)
            {
                IncreasePoolSize(poolSizeIncreaseAmount);
            }

            Bullet bullet = _bullets[0];
            _bullets.RemoveAt(0);

            return bullet;
        }

        public void ReturnBullet(Bullet bullet)
        {
            _bullets.Add(bullet);
        }

        private void IncreasePoolSize(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Bullet bullet = Instantiate(bulletPrefab, transform);
                bullet.OnBulletDisabled += () => ReturnBullet(bullet);
                _bullets.Add(bullet);
            }
        }
    }
}