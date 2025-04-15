using System;
using UnityEngine;

namespace ShooterSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float deathTime;
        [SerializeField] private LayerMask hitableLayers;

        private float _speed;

        void Update()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            float distance = _speed * Time.deltaTime;

            if (Physics.Raycast(ray, out RaycastHit hit, distance, hitableLayers))
            {
                OnHit(hit);
            }
            else
            {
                transform.position = ray.GetPoint(distance);
            }
        }

        private void OnDisable()
        {
            
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