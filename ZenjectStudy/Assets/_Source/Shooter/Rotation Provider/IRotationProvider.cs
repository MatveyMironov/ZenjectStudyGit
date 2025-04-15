using UnityEngine;

namespace ShooterSystem
{
    public interface IRotationProvider
    {
        public Quaternion GetRotation();
    }
}