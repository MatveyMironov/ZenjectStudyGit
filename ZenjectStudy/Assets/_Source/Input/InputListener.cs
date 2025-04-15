using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKey;

        private void Update()
        {
            if (Input.GetKeyDown(shootKey))
            {
                OnShootInput();
            }
        }

        private void OnShootInput()
        {

        }
    }
}