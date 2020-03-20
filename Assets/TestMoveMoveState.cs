using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveMoveState : MovementStateBase
{
    float mouseX = 0;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, animatorStateInfo, layerIndex);
        ToIdle += ToIdleState;
        mouseX = character.transform.eulerAngles.y;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        base.OnStateExit(animator, animatorStateInfo, layerIndex);
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

    protected override void Move(Vector3 _direction)
    {
        base.Move(_direction);
        Rotate();
    }
    private void Rotate()
    {
        mouseX += Input.GetAxis("Mouse X") * m_inputController.RotationSpeed;
        character.transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
