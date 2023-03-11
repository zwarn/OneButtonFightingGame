using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBehavior : StateMachineBehaviour
{
    private static readonly int Charge = Animator.StringToHash("Charge");
    private static readonly int Punch = Animator.StringToHash("Punch");
    private static readonly int Jump = Animator.StringToHash("Jump");
    protected PlayerController playerController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        playerController = animator.GetComponent<PlayerController>();
        playerController.CurrentState = this;

        animator.ResetTrigger(Jump);
        animator.ResetTrigger(Punch);
        animator.ResetTrigger(Charge);
    }

    public virtual void Act(float charge, Animator animator)
    {
    }
}