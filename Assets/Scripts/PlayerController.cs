using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody), typeof(ChargeHandler))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private ChargeHandler _chargeHandler;
    private Animator _animator;
    public StateBehavior CurrentState { get; set; }
    public bool right = true;
    public PlayerController Opponent;
    public PowerBard PowerBard;
    private int score;
    public TMP_Text scoreText;
    private static readonly int Land = Animator.StringToHash("Land");
    private static readonly int DisengageTrigger = Animator.StringToHash("Disengage");

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _chargeHandler = GetComponent<ChargeHandler>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var charge = _chargeHandler.charge;
        PowerBard.holdAmount = charge;
        PowerBard.enableJump = charge > 0 && charge < IdleState.jumpTiming;
        PowerBard.enablePunish = charge > IdleState.jumpTiming && charge < IdleState.punchTiming;
        PowerBard.enableCharge = charge > IdleState.punchTiming;
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
        var punchPower = 200 * DirectionScale();
        _rigidbody.AddForce(punchPower, 0, 0);
    }

    public void Charge(float power)
    {
        var chargePower = 1000 * DirectionScale();
        _rigidbody.AddForce(chargePower, 0, 0);
    }

    public void Flip()
    {
        right = !right;
    }

    public float VerticalVelocity()
    {
        return _rigidbody.velocity.y;
    }

    public float HorizontalVelocity()
    {
        return _rigidbody.velocity.x * DirectionScale();
    }

    public float DirectionScale()
    {
        return right ? 1 : -1;
    }

    private void OnLand()
    {
        _animator.SetTrigger(Land);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            OnLand();
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnCollide();
        }
    }

    private void OnCollide()
    {
        Disengage();
    }

    public void OnHit()
    {
        Disengage();
        score += 1;
        scoreText.text = score.ToString();
    }

    public void OnHurt()
    {
        Disengage();
    }

    private void Disengage()
    {
        _animator.SetTrigger(DisengageTrigger);
        var xMovement = 500 * Mathf.Sign(transform.transform.position.x - Opponent.transform.position.x);
        _rigidbody.AddForce(xMovement, 200, 0);
    }
}