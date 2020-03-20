using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveIdleState : MovementStateBase
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        ToMov += ToMoveState;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        ToMov -= ToMoveState;
    }
    protected override void SetMovementType(int _x)
    {
        base.SetMovementType(_x);
        SetupType(myType.Idle);
    }
    
    private void ToMoveState()
    {
        m_inputController.animator.SetTrigger("Move");
    }
}
