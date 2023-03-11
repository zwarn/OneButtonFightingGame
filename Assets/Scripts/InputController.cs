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
        GetInput(playerOne, KeyCode.A);
        GetInput(playerTwo, KeyCode.LeftArrow);
    }

    private void GetInput(PlayerController playerController, KeyCode charge)
    {
        if (Input.GetKeyDown(charge))
        {
            playerController.ButtonDown();
        }

        if (Input.GetKeyUp(charge))
        {
            playerController.ButtonUp();
        }
    }
}