using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveMoveState : MovementStateBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        ToIdle += ToIdleState;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ToIdle -= ToIdleState;
    }
    protected override void SetMovementType(int _x)
    {
        base.SetMovementType(_x);
        SetupType(myType.Move);
    }

    private void ToIdleState()
    {
        m_inputController.animator.SetTrigger("Stop");
    }
}
