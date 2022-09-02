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

    void FixedUpdate()
    {
        float x = Mathf.Sin(2 * Mathf.PI * Time.fixedTime * Velocity) * Radius + Planet.position.x;
        float y = Mathf.Cos(2 * Mathf.PI * Time.fixedTime * Velocity) * Radius + Planet.position.y;
        transform.position = new Vector3(x, y, 0f);

        Vector3 relatedPosition = transform.position - Planet.position ;

        float angle = Mathf.Atan2(relatedPosition.x, relatedPosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
    }
}