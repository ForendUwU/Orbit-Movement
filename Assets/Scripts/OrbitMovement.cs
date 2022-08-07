using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public Transform Planet;

    public float Radius;
    public float RadiusVelovity;
    public float RotationVelocity;

    private Vector3 axis;

    void Start()
    {
        axis = Vector3.forward;
    }

    void Update()
    {
        transform.RotateAround(Planet.position, axis, RotationVelocity * Time.deltaTime);
        transform.position = (transform.position - Planet.position).normalized * Radius;
        if (Radius < 1)
        {
            Radius = 1;
        }
    }
}