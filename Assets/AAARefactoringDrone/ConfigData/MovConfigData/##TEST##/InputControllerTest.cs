using System;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerTest : MonoBehaviour
{
    #region Actions
    public Action<Vector3> Move;
    public Action<int> ChangeType;
    #endregion

    #region PublicValues
    public int CurrentTypeIndex;
    public int WalkIndex;
    public int RunIndex;
    public int CrouchIndex;

    public float acceleration;
    public float friction;

    public float RotationSpeed;

    public CharacterController CharacterController;
    public BlendTreeTEST Graphics;
    public Animator animator;
    public Transform movementTransform;
    #endregion
    

    // Update is called once per frame
    void Update()
    {
        UpdateMoveDirection();

        ChangeMoveType();
    }

    private void UpdateMoveDirection()
    {
        Move?.Invoke(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
    }

    private void ChangeMoveType()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            if (CurrentTypeIndex != CrouchIndex)
            {
                CurrentTypeIndex = CrouchIndex;
                ChangeType?.Invoke(CurrentTypeIndex);
            }
            else
            {
                CurrentTypeIndex = WalkIndex;
                ChangeType?.Invoke(CurrentTypeIndex);
            }
        }
        else if (Input.GetButtonDown("Run"))
        {
            CurrentTypeIndex = RunIndex;
            ChangeType?.Invoke(CurrentTypeIndex);
        }
        else if (Input.GetButtonUp("Run"))
        {
            CurrentTypeIndex = WalkIndex;
            ChangeType?.Invoke(CurrentTypeIndex);
        }
    }
}
