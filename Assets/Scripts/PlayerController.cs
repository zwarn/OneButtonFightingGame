using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovePower = 100;
    private Rigidbody _rigidbody;
    private float xForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveLeft()
    {
        Move(-1);
    }

    public void MoveRight()
    {
        Move(1);
    }

    public void Move(int direction)
    {
        xForce = direction * MovePower;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(xForce, 0, 0));
        xForce = 0;
    }
}