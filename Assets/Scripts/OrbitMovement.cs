using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public float Velocity;
    public float Radius;

    private float timer;

    void Start()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime * Velocity;

        float x = Mathf.Sin(timer) * Radius;
        float y = Mathf.Cos(timer) * Radius;

        transform.position = new Vector3(x, y, 0);

        float angle = -57 * Time.deltaTime;

        transform.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);
    }
}