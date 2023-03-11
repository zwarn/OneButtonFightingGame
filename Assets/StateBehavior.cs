using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBehavior : StateMachineBehaviour
{
    public virtual void Act(float charge, Animator animator)
    {
    }
}