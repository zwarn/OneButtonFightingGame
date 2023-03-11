using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ChargeHandler))]
public class PlayerController : MonoBehaviour
{
    public float MovePower = 100;
    private Rigidbody _rigidbody;
    private ChargeHandler _chargeHandler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _chargeHandler = GetComponent<ChargeHandler>();
    }

    public void ButtonDown()
    {
        _chargeHandler.StartCharge();
    }

    public void ButtonUp()
    {
        var charge = _chargeHandler.charge;
        _chargeHandler.ResetCharge();
        _rigidbody.AddForce(0, MovePower * charge, 0);
    }
}