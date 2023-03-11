using System;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public PlayerController owner;

    private void OnCollisionEnter(Collision collision)
    {
        owner.OnHurt();
        owner.Opponent.OnHit();
    }
}