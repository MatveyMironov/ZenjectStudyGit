using ShooterSystem;
using UnityEngine;

public class TransformRotationProvider : MonoBehaviour, IRotationProvider
{
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }
}
