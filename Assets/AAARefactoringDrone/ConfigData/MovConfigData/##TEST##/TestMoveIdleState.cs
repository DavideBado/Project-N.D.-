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
        base.OnStateExit(animator, animatorStateInfo, layerIndex);
        ToMov -= ToMoveState;
    }
    protected override void SetMovementType(int _x)
    {
        base.SetMovementType(_x);
        SetupType(myType.Idle);
    }

    private void ToMoveState()
    {
        UpdateRotation();
        m_inputController.animator.SetTrigger("Move");
    }

    private void UpdateRotation()
    {
        m_inputController.movementTransform.position = Camera.main.transform.position;
        m_inputController.movementTransform.rotation = Camera.main.transform.rotation;
        m_inputController.movementTransform.eulerAngles = new Vector3(0, m_inputController.movementTransform.eulerAngles.y, m_inputController.movementTransform.eulerAngles.z);

        character.transform.rotation = m_inputController.movementTransform.rotation;
    }
}
