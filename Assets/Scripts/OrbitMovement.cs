using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public float Velocity;
    public float Radius;

    void FixedUpdate()
    {
        float x = Mathf.Sin(2 * Mathf.PI * Time.fixedTime * Velocity) * Radius;
        float y = Mathf.Cos(2 * Mathf.PI * Time.fixedTime * Velocity) * Radius;
        transform.position = new Vector3(x, y, 0f);

        float angle = Time.fixedTime * Velocity;
        transform.rotation *= Quaternion.AngleAxis(-0.28f, Vector3.forward);
    }
}