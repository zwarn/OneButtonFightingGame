using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(ChargeHandler))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private ChargeHandler _chargeHandler;
    private Animator _animator;
    public StateBehavior CurrentState { get; set; }
    public bool right = true;
    public PlayerController Opponent;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _chargeHandler = GetComponent<ChargeHandler>();
        _animator = GetComponent<Animator>();
    }

    public void ButtonDown()
    {
        _chargeHandler.StartCharge();
    }

    public void ButtonUp()
    {
        var charge = _chargeHandler.charge;
        _chargeHandler.ResetCharge();
        CurrentState.Act(charge, _animator);
    }

    public void Jump()
    {
        var jumpPower = 400;
        _rigidbody.AddForce(0, jumpPower, 0);
    }

    public void Punch()
    {
        var punchPower = 200 * (right ? 1 : -1);
        _rigidbody.AddForce(punchPower, 0, 0);
    }

    public void Charge()
    {
        var chargePower = 1000 * (right ? 1 : -1);
        _rigidbody.AddForce(chargePower, 0, 0);
    }

    public void Flip()
    {
        right = !right;
        Debug.Log("flip");
    }
}