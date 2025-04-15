using System;
using UnityEngine;

namespace ShooterSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float deathTime;
        [SerializeField] private LayerMask hitableLayers;

        private float _speed;

        private float _lifeTime = 0.0f;

        public event Action OnBulletDisabled;

        void Update()
        {
            Ray ray = new(transform.position, transform.forward);
            float distance = _speed * Time.deltaTime;

            if (Physics.Raycast(ray, out RaycastHit hit, distance, hitableLayers))
            {
                OnHit(hit);
            }
            else
            {
                transform.position = ray.GetPoint(distance);
            }

            _lifeTime += Time.deltaTime;

            if (_lifeTime >= deathTime)
            {
                _lifeTime = 0.0f;
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            OnBulletDisabled?.Invoke();
        }

        private void OnHit(RaycastHit hit)
        {
            transform.position = hit.point;

            if (hit.collider.TryGetComponent(out IHitable hitable))
            {
                hitable.Hit();
            }

            gameObject.SetActive(false);
        }

        public void Setup(float speed)
        {
            _speed = speed;
        }
    }
}