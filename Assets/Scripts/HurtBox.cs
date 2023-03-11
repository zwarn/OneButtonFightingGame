using System;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public PlayerController owner;
    public GameObject hitEffect;

    private void OnTriggerEnter(Collider other)
    {
        owner.OnHurt();
        owner.Opponent.OnHit();

        if (hitEffect != null)
        {
            var position = (owner.transform.position + owner.Opponent.transform.position) / 2;
            Instantiate(hitEffect, position, Quaternion.identity);
        }
    }
}