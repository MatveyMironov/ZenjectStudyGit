using System;
using UnityEngine;

namespace ShooterSystem
{
    public class TransformPositionProvider : MonoBehaviour, IPositionProvider
    {
        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}