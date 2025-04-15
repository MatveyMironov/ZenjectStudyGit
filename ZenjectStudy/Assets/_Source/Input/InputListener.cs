using ShooterSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKey;

        private Shooter _shooter;

        private void Update()
        {
            if (Input.GetKeyDown(shootKey))
            {
                OnShootInput();
            }
        }

        public void Setup(Shooter shooter)
        {
            _shooter = shooter;
        }

        private void OnShootInput()
        {
            _shooter?.Shoot();
        }
    }
}