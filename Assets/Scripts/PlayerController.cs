using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 100;
    private float deltaX = 0;


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
        deltaX += direction * MoveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        transform.Translate(deltaX, 0, 0);
        deltaX = 0;
    }
}