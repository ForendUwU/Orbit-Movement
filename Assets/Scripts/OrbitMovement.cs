using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public float Velocity;
    public float Radius;

    public Transform Planet;

    private void FixedUpdate()
    {
        float x = Mathf.Sin(Time.fixedTime * Velocity * Time.fixedDeltaTime) * Radius + Planet.position.x;
        float y = Mathf.Cos(Time.fixedTime * Velocity * Time.fixedDeltaTime) * Radius + Planet.position.y;
        transform.position = new Vector3(x, y, 0f);

        Vector3 relativePosition = transform.position - Planet.position;

        float anglularVelocity = Mathf.Atan2(relativePosition.x, relativePosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-anglularVelocity, Vector3.forward);
    }
}