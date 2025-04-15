using InputSystem;
using ShooterSystem;
using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    [Inject]
    private void Bootstrap(InputListener inputListener, Shooter shooter)
    {
        inputListener.Setup(shooter);
    }
}
