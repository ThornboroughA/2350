using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RigidbodyData", menuName = "ScriptableObjects/RigidbodyData", order = 1)]
public class RigidbodyData : ScriptableObject
{
    public float mass = 1.0f;
    public float drag = 0.0f;
    public float angularDrag = 0.05f;
    public bool useGravity = true;
    public RigidbodyInterpolation interpolation = RigidbodyInterpolation.None;
    public CollisionDetectionMode collisionDetection = CollisionDetectionMode.Discrete;
}
