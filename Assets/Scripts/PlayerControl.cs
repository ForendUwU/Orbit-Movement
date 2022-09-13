using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public float AngularVelocity;
    public float Radius;

    public Transform Planet;
    public GameObject PlanetPrefab;

    public float MovementVelocity;

    private bool isTouched;

    private void Start()
    {
        isTouched = false;
        PlanetPrefab = GameObject.Find("Planet(Clone)");
    }

    private void FixedUpdate()
    {
        if (!isTouched)
        {
            float x = Mathf.Sin(Time.fixedTime * AngularVelocity * Time.fixedDeltaTime) * Radius + Planet.position.x;
            float y = Mathf.Cos(Time.fixedTime * AngularVelocity * Time.fixedDeltaTime) * Radius + Planet.position.y;
            transform.position = new Vector3(x, y, 0f);

            Vector3 relativePosition = transform.position - Planet.position;

            float anglularVelocity = Mathf.Atan2(relativePosition.x, relativePosition.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-anglularVelocity, Vector3.forward);
        }

        Vector3 trueDir = transform.rotation * Vector3.up;
        Debug.DrawRay(transform.position, trueDir, Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, trueDir);

        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            isTouched = true;
        }

        if (isTouched)
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, MovementVelocity * Time.fixedDeltaTime);
            if (hit.transform.gameObject == PlanetPrefab)
            {
                Planet = PlanetPrefab.transform;
                if (transform.position.x > PlanetPrefab.transform.position.x - 0.3 && transform.position.x < PlanetPrefab.transform.position.x + 0.3 || transform.position.y > PlanetPrefab.transform.position.y - 0.3 && transform.position.y < PlanetPrefab.transform.position.x + 0.3)
                {
                    isTouched = false;
                }
            }

        }
    }
}