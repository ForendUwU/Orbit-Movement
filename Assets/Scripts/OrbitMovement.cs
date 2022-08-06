using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public Transform Center;

    public float Radius;
    public float RadiusVelovity;
    public float RotationVelocity;

    private Vector3 axis;
    private Vector3 DesiredPosition;

    void Start()
    {
        transform.position = (transform.position - Center.position).normalized * Radius + Center.position;
        axis = Vector3.forward;
    }

    void Update()
    {
        transform.RotateAround(Center.position, axis, RotationVelocity * Time.deltaTime);
        DesiredPosition = (transform.position - Center.position).normalized * Radius + Center.position;
        transform.position = Vector3.MoveTowards(transform.position, DesiredPosition, RadiusVelovity * Time.deltaTime);
    }
}
