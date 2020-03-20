using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Loading : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        List<GameObject> cameras = new List<GameObject>();
        Movement_ConfigData _data = animator.GetComponent<InputControllerTest>().Graphics.movementData;
        for (int i = 0; i < _data.characterMovType_Datas.Length; i++)
        {
             GameObject _camera = Instantiate(_data.characterMovType_Datas[i].GraphicsData.CameraPrefab, animator.transform);
            _data.characterMovType_Datas[i].GraphicsData.m_VirtualCamera = _camera.GetComponent<CinemachineVirtualCameraBase>();

            if (_camera.GetComponent<CinemachineFreeLook>())
            {
                _camera.transform.parent = animator.transform.parent;
                _data.characterMovType_Datas[i].GraphicsData.m_VirtualCamera.Follow = animator.transform;
                _data.characterMovType_Datas[i].GraphicsData.m_VirtualCamera.LookAt = animator.transform;
            }
        }

        animator.SetTrigger("Loaded");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
