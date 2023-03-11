using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChargeState : StateBehavior
{
    private static readonly int ChargePower = Animator.StringToHash("ChargePower");

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        playerController.Charge(animator.GetFloat(ChargePower));
        animator.SetFloat(ChargePower, 0);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }

    public override void Act(float charge, Animator animator)
    {
        return;
    }
}