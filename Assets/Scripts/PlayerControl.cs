using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public float Velocity;
    public float Radius;

    public Transform Planet;

    private bool isTouched;

    private void Start()
    {
        isTouched = false;
    }

    private void FixedUpdate()
    {
        if (!isTouched)
        {
            float x = Mathf.Sin(Time.fixedTime * Velocity * Time.fixedDeltaTime) * Radius + Planet.position.x;
            float y = Mathf.Cos(Time.fixedTime * Velocity * Time.fixedDeltaTime) * Radius + Planet.position.y;
            transform.position = new Vector3(x, y, 0f);

            Vector3 relativePosition = transform.position - Planet.position;

            float anglularVelocity = Mathf.Atan2(relativePosition.x, relativePosition.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-anglularVelocity, Vector3.forward);
        }

        Vector3 trueDir = transform.rotation * Vector3.up;
        Debug.DrawRay(transform.position, trueDir, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, trueDir);

        if (Input.touchCount > 0)
        {
            isTouched = true;
        }

        if (isTouched)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, Velocity/1000);
        }
    }
}