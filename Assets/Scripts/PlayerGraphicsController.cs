using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerGraphicsController : MonoBehaviour
{
    //public Action WalkStep;
    //public Action RunStep;

    public NoiseController noiseController;
    public PlayerMovController PlayerController;
    public Animator animator;

    //private void OnEnable()
    //{
    //    WalkStep += WalkStepNoise;
    //    RunStep += RunStepNoise;
    //}

    //private void OnDisable()
    //{
    //    WalkStep -= WalkStepNoise;
    //    RunStep -= RunStepNoise;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", PlayerController.GraphSpeed);
        if(PlayerController.isCrouching) animator.SetFloat("Crouch", 5f);
        else animator.SetFloat("Crouch", 0);
    }

    private void WalkStep()
    {
        noiseController.MakeNoise(4, 1, NoiseController.NoiseType.Walk);
    }

    private void RunStep()
    {
        noiseController.MakeNoise(5, 1, NoiseController.NoiseType.Run);
    }
}
