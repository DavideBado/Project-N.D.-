using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendTreeTEST : MonoBehaviour
{
    public Animator animator;
    public Movement_ConfigData movementData;
    bool CanChangeAnim = false;

    public float Speed;
    public float Height;

    private void Start()
    {
        movementData.Init(animator);
    }
    private void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{ movementData.Init(animator);
        //    CanChangeAnim = true;
        //}
        //if(CanChangeAnim)
        //{
            animator.SetFloat("Speed", Speed);
            animator.SetFloat("Height", Height);
        //}
           
    }
}
