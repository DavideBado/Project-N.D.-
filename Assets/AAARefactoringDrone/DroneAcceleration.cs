using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAcceleration : DroneMoveState
{
    float acceleration;

    Vector3 CurrentInputDirection = new Vector3();
    Vector3 OldInputDirection = new Vector3();
    Vector3 _Vm = new Vector3();
          Vector3 OldDirection = Vector3.zero;
    Vector3 CurrentDirection = new Vector3();

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 _inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        if (OldDirection != Vector3.zero)
        {
            float _decelValue = Mathf.Clamp((data.decel_k * OldDirection.magnitude) / data.decel_m, 0, OldDirection.magnitude);
            float _decel = Mathf.Round((OldDirection.magnitude - _decelValue * Time.deltaTime) * 10f) / 10f;

            if (_inputDirection == Vector3.zero && _decel < 4) _decel = 0;

            OldDirection = OldDirection.normalized * _decel;
        }

        float _acceleration = Mathf.Sqrt(Mathf.Pow(data.Acceleration_Z * _inputDirection.z, 2) + Mathf.Pow(data.Acceleration_X * _inputDirection.x, 2));

        _inputDirection = _inputDirection.normalized * _acceleration * Time.deltaTime;

        CurrentDirection = OldDirection + _inputDirection;

        CurrentDirection = CurrentDirection.normalized * Mathf.Clamp(CurrentDirection.magnitude, 0, data.SpeedMaxValue);

        Debug.ClearDeveloperConsole();
         Debug.Log("Speed: " + CurrentDirection.magnitude.ToString("F2"));

        DroneCharaCtrl.Move(CurrentDirection * Time.deltaTime);
        OldDirection = CurrentDirection;
    }
    //{
    //    CurrentInputDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    //    if(CurrentInputDirection.normalized != OldInputDirection.normalized && CurrentInputDirection != Vector3.zero)
    //    {
    //        OldInputDirection = CurrentInputDirection.normalized;
    //        CurrentInputDirection = CurrentInputDirection.normalized * 0.01f;
    //    }
    //    acceleration = Mathf.Sqrt(Mathf.Pow(data.Acceleration_Z * CurrentInputDirection.z, 2) + Mathf.Pow(data.Acceleration_X * CurrentInputDirection.x, 2));




    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
