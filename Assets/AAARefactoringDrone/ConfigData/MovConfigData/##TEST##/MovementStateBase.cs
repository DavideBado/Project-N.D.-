using System;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateBase : StateMachineBehaviour
{
    protected Action ToMov;
    protected Action ToIdle;

    protected InputControllerTest m_inputController;
    protected Movement_ConfigData movementData;
    protected MovementLogic_ConfigData m_data;
    protected BlendTreeTEST treeTEST;
    protected float m_maxSpeed;
    protected float currentSpeed;
    protected float height;
    protected MovementLogic_ConfigData.MoveType myType;
    protected CharacterController character;
    Vector3 OldDirection;
    Vector3 CurrentDirection;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        m_inputController = animator.GetComponent<InputControllerTest>();
        treeTEST = m_inputController.Graphics;
        movementData = treeTEST.movementData;
        character = m_inputController.CharacterController;
        m_data = movementData.LogicData;
 
        m_inputController.ChangeType += SetMovementType;
        SetMovementType(m_inputController.CurrentTypeIndex);

        m_inputController.Move += Move;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        m_inputController.ChangeType -= SetMovementType;
        m_inputController.Move -= Move;
    }


    protected virtual void SetMovementType(int _x)
    {
        for (int i = 0; i < movementData.characterMovType_Datas.Length; i++)
        {
            movementData.characterMovType_Datas[i].GraphicsData.m_VirtualCamera.Priority = 0;
        }
        myType = m_data.MoveTypes[_x];
        m_maxSpeed = myType.Move.LogicData.Speed;
        height = myType.Idle.LogicData.Height;
        treeTEST.Height = height;
    }

    protected void SetupType(CharacterMovType_ConfigData _myMovType)
    {
        _myMovType.GraphicsData.m_VirtualCamera.Priority = 50;
    }

    protected virtual void Move(Vector3 _direction)
    {
        Vector3 _inputDirection = Quaternion.Euler(0, character.transform.eulerAngles.y, 0) * _direction;

        float _acceleration = Mathf.Sqrt(Mathf.Pow(m_inputController.acceleration * _inputDirection.z, 2) + Mathf.Pow(m_inputController.acceleration * _inputDirection.x, 2));

        _inputDirection = _inputDirection.normalized * _acceleration * Time.deltaTime;

        CurrentDirection = OldDirection + _inputDirection;

        CurrentDirection = CurrentDirection.normalized * Mathf.Clamp(CurrentDirection.magnitude, 0, m_maxSpeed);
        character.Move(CurrentDirection * Time.deltaTime);
        currentSpeed = CurrentDirection.magnitude;

        treeTEST.Speed = currentSpeed;

        OldDirection = CurrentDirection.normalized * Mathf.Clamp(currentSpeed - (m_inputController.friction * Time.deltaTime), 0, m_maxSpeed);

        if (currentSpeed == 0) ToIdle?.Invoke();
        else ToMov?.Invoke();
    }
}
