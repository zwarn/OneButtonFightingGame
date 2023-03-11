using System;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public PlayerController owner;

    private void OnTriggerEnter(Collider other)
    {
        owner.OnHurt();
        owner.Opponent.OnHit();
    }
}