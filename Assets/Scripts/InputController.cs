using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerController playerOne;
    public PlayerController playerTwo;

    private void Update()
    {
        GetInput(playerOne, KeyCode.A, KeyCode.D);
        GetInput(playerTwo, KeyCode.LeftArrow, KeyCode.RightArrow);
    }

    private void GetInput(PlayerController playerController, KeyCode left, KeyCode right)
    {
        if (Input.GetKey(left))
        {
            playerController.MoveLeft();
        }

        if (Input.GetKey(right))
        {
            playerController.MoveRight();
        }
    }
}