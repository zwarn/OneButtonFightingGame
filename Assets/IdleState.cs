using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class IdleState : StateBehavior
{
    public static float jumpTiming = 0.1f;
    public static float punchTiming = 0.3f;
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Punch = Animator.StringToHash("Punch");
    private static readonly int Charge = Animator.StringToHash("Charge");

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        var player = playerController;
        var opponent = player.Opponent;

        var shouldFaceRight = player.transform.position.x - opponent.transform.position.x < 0;

        if (player.right != shouldFaceRight)
        {
            player.Flip();
        }
    }

    public override void Act(float charge, Animator animator)
    {
        if (charge == 0)
        {
            return;
        }

        if (charge < jumpTiming)
        {
            animator.SetTrigger(Jump);
        }
        else if (charge < punchTiming)
        {
            animator.SetTrigger(Punch);
        }
        else
        {
            animator.SetTrigger(Charge);
        }
    }
}